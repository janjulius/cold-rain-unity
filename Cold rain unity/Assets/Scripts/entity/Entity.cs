﻿using Assets.Scripts.contants;
using Assets.Scripts.interactable;
using Assets.Scripts.logger;
using Assets.Scripts.npc;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.stats;
using Assets.Scripts.util;
using System;
using UnityEngine;
using static Assets.Scripts.contants.Constants;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : Node, Iinteractable
{
    public Vector2 SpawnPosition = new Vector2(0.5f, 0.5f);
    public FaceDirection SpawnFaceDirection;
    public string EntityName;

    protected Animator animator;

    public Skills skills
    {
        get;
        protected set;
    }

    public Stats stats
    {
        get;
        protected set;
    }

    public void SetEntityName (string name)
    {
        EntityName = name;
    }

    private Stats baseStats;
    private Stats bonusStats;

    public EquipmentSlots equipment
    {
        get;
        set;
    }

    protected int hitPoints;
    protected int energy;

    private FaceDirection faceDirection;
    protected FaceDirection FaceDirection
    {
        set
        {
            faceDirection = value;
            OnIsMovingChanged(IsMoving);
        }
        get
        {
            return faceDirection;
        }
    }

    private bool isMoving;
    public bool IsMoving
    {
        private set
        {
            isMoving = value;
            OnIsMovingChanged(value);
        }
        get
        {
            return isMoving;
        }
    }
    public bool CanMove { private set; get; }

    public bool IsLocked { private set; get; }

    #region Timers
    public float EntityTimer { get; private set; }

    /// <summary>
    /// Blocks moving if this is higher than the entitytimer
    /// </summary>
    public float MoveBlockTimer { get; set; }

    /// <summary>
    /// Complete player lock
    /// </summary>
    public float LockTimer { get; set; }

    #endregion


    #region MovingVariables

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timeToReachTarget;
    private float timeM;
    private bool ForceDestination;

    #endregion

    private Rigidbody2D rb;

    #region Facing Nodes
    [HideInInspector] public Entity facingEntity;
    protected Interactable facingInteractable;
    #endregion

    protected string[] NonPassableLayers = new string[]
    {
        "ObjectCollision", "Entity"
    };

    private string[] InteractableLayers = new string[]
    {
        "Entity", "Interactable"
    };

    public override void StartInitiate()
    {
        base.Initiate();
        IsLocked = false;
        startPosition = SpawnPosition;
        targetPosition = SpawnPosition;
        SetLayer((int)UnityLayers.ENTITY);
        rb = GetComponent<Rigidbody2D>();
        SetLocation(SpawnPosition);
        baseStats = gameObject.AddComponent<Stats>();
        UpdateBaseStats();
        bonusStats = gameObject.AddComponent<Stats>();
        skills = gameObject.AddComponent<Skills>();
        UpdateStats();

        animator = GetComponent<Animator>();

        if (this is Player)
        {
            equipment = gameObject.GetComponent<EquipmentSlots>();
        }

    }

    public void Update()
    {
        EntityUpdate();
        MovementUpdate();
        UpdateTimers();
    }

    protected virtual void EntityUpdate()
    {
        EntityTimer += Time.deltaTime;
    }

    private void UpdateTimers()
    {
        CanMove = EntityTimer <= MoveBlockTimer;
        IsLocked = EntityTimer <= LockTimer;
    }

    /// <summary>
    /// Blocks the entity from moving for time in milliseconds
    /// </summary>
    /// <param name="time"></param>
    public void BlockMovement(float time)
    {
        MoveBlockTimer = EntityTimer + time;
    }

    public void UnlockMovement()
    {
        MoveBlockTimer = 0;
    }

    /// <summary>
    /// blocks the entity from doing any interaction for time in millis
    /// </summary>
    /// <param name="time"></param>
    public void Lock(float time)
    {
        LockTimer = EntityTimer + time;
    }

    /// <summary>
    /// Locks for a very long time, requires <see cref="Unlock"/>
    /// </summary>
    public void Lock()
    {
        LockTimer = EntityTimer + 100_000_000f;
    }

    public void Unlock()
    {
        LockTimer = 0;
    }

    /// <summary>
    /// Updates all the movement code
    /// </summary>
    private void MovementUpdate()
    {
        if (!ForceDestination)
        {
            timeM += Time.deltaTime / timeToReachTarget;
            float step = timeToReachTarget * Time.deltaTime;

            transform.position = Vector2.Lerp(startPosition, targetPosition, timeM);
            if ((new Vector2(transform.position.x, transform.position.y) != targetPosition) != IsMoving)
                IsMoving = new Vector2(transform.position.x, transform.position.y) != targetPosition;
        }
        else
        {
            transform.position = targetPosition;
            ForceDestination = false;
        }
    }
    
    protected Vector2 GetNextTargetPosition(FaceDirection faceDirection)
    {
        switch (faceDirection)
        {
            case FaceDirection.DOWN:
                return new Vector2(transform.position.x, transform.position.y - TILE_SIZE);
            case FaceDirection.UP:
                return new Vector2(transform.position.x, transform.position.y + TILE_SIZE);
            case FaceDirection.LEFT:
                return new Vector2(transform.position.x - TILE_SIZE, transform.position.y);
            case FaceDirection.RIGHT:
                return new Vector2(transform.position.x + TILE_SIZE, transform.position.y);
        }
        return transform.position;
    }

    /// <summary>
    /// Update the stats of the entity
    /// </summary>
    protected void UpdateStats(Stats bonusStats)
    {
        if(bonusStats != null)
            this.bonusStats = bonusStats;
        stats = baseStats + bonusStats;
        timeToReachTarget = 1 / stats.Speed;
    }

    protected void UpdateStats()
    {
        stats = baseStats + bonusStats;
        timeToReachTarget = 1 / stats.Speed;
    }

    /// <summary>
    /// Set the next destination of this entity
    /// </summary>
    /// <param name="loc"></param>
    public virtual void SetDestination(Vector2 loc)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetVectorDirection(FaceDirection), Constants.TILE_SIZE, LayerMask.GetMask(NonPassableLayers));


        if ((hit.collider == null || this is NPC))
        {
            Move(loc);
        }
        else
        {
            if(Vector2.Distance(hit.collider.gameObject.transform.position, loc) == 1)
            {
                Move(loc);
            }
        }
    }

    private void Move(Vector2 loc)
    {
        if (!CanMove)
        {
            timeM = 0;
            startPosition = transform.position;
            targetPosition = loc;
        }
    }

    protected Vector2 GetVectorDirection(FaceDirection dir)
    {
        if (dir == FaceDirection.DOWN)
            return Vector2.down;
        else if (dir == FaceDirection.RIGHT)
            return Vector2.right;
        else if (dir == FaceDirection.LEFT)
            return Vector2.left;
        else
            return Vector2.up;
    }

    public void SetLocation(Vector2 loc)
    {
        Vector2 l = MathUtilities.RoundToNearestHalves(loc);
        ForceDestination = true;
        startPosition = l;
        targetPosition = l;
    }

    public void SetLocation(float x, float y)
        => SetLocation(new Vector2(x, y));

    public virtual void Face(FaceDirection dir)
    {
        FaceDirection = dir;
    }

    /// <summary>
    /// Updates the base stats
    /// </summary>
    protected virtual void UpdateBaseStats()
    {
        baseStats = new Stats(10, 5, 1, 1, 1, 5, 1, 0, 1, 1);
    }

    public virtual void Interact(Entity sender)
    {
        CrLogger.Log(this, $"Entity interaction (obj name:{name})", CrLogger.LogType.DEFAULT);
        FaceDirection fdir = GetFaceDirection(sender);
        Face(fdir);
    }

    private FaceDirection GetFaceDirection(Entity faceTo)
    {
        return faceTo.FaceDirection + ((int)faceTo.FaceDirection >= 2 ? -2 : 2);
    }

    #region Events

    protected void OnIsMovingChanged(bool value)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetVectorDirection(FaceDirection), Constants.TILE_SIZE, LayerMask.GetMask(InteractableLayers));
        if (hit.collider != null)
        {
            facingEntity = hit.collider.GetComponent<Entity>();
            facingInteractable = hit.collider.GetComponent<Interactable>();
        } else
        {
            facingEntity = null;
            facingInteractable = null;
        }
    }

    #endregion

    public Vector2 position()
    {
        return transform.position;
    }
}
