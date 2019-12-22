using Assets.Scripts.contants;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : Node
{
    protected FaceDirection faceDirection;

    public Vector2 SpawnPosition;

    protected Skills skills;

    protected Stats stats;

    private Stats baseStats;
    private Stats bonusStats;
    
    protected EquipmentSlots equipment;

    protected int hitPoints;
    protected int energy;

    public bool IsMoving { private set; get; }

    #region MovingVariables

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timeToReachTarget;
    private float timeM;
    private bool ForceDestination;

    #endregion

    private Rigidbody2D rb;


    private string[] NonPassableLayers = new string[]
    {
        "ObjectCollision"
    };

    public override void StartInitiate()
    {
        base.Initiate();
        startPosition = SpawnPosition; targetPosition = SpawnPosition;
        rb = GetComponent<Rigidbody2D>();
        SetLocation(SpawnPosition);
        baseStats = gameObject.AddComponent<Stats>();
        UpdateBaseStats();
        bonusStats = gameObject.AddComponent<Stats>();
        skills = gameObject.AddComponent<Skills>();
        UpdateStats();
        
        if(this is Player)
        {
            equipment = gameObject.AddComponent<EquipmentSlots>();
        }

    }

    public void Update()
    {
        EntityUpdate();
        MovementUpdate();
    }

    public virtual void EntityUpdate()
    {

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
            IsMoving = new Vector2(transform.position.x, transform.position.y) != targetPosition;
        }
        else
        {
            transform.position = targetPosition;
            ForceDestination = false;
        }
    }

    /// <summary>
    /// Update the stats of the entity
    /// </summary>
    private void UpdateStats()
    {
        stats = baseStats + bonusStats;
        timeToReachTarget = 1 / stats.Speed;
    }

    /// <summary>
    /// Set the next destination of this entity
    /// </summary>
    /// <param name="loc"></param>
    public void SetDestination(Vector2 loc)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetVectorDirection(faceDirection), Constants.TILE_SIZE, LayerMask.GetMask(NonPassableLayers));
        if (hit.collider == null)
        {
            timeM = 0;
            startPosition = transform.position;
            targetPosition = loc;
        }
    }

    private Vector2 GetVectorDirection(FaceDirection dir)
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
        print($"Setting location for {name} to {loc}");
        ForceDestination = true;
        startPosition = loc;
        targetPosition = loc;
    }

    public virtual void Face(FaceDirection dir)
    {
        faceDirection = dir;
    }

    /// <summary>
    /// Updates the base stats
    /// </summary>
    protected virtual void UpdateBaseStats()
    {
        baseStats = new Stats(10, 5, 1, 1, 1, 5, 1, 0, 1, 1);
    }
}
