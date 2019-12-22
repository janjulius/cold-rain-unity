using Assets.Scripts.player.Equipment;
using Assets.Scripts.stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Node
{
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

    #endregion
    
    public override void StartInitiate()
    {
        base.Initiate();
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
        timeM += Time.deltaTime / timeToReachTarget;
        float step = timeToReachTarget * Time.deltaTime;
        transform.position = Vector2.Lerp(startPosition, targetPosition, timeM);
        IsMoving = new Vector2(transform.position.x, transform.position.y) != targetPosition;
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
        timeM = 0;
        startPosition = transform.position;
        targetPosition = loc;
    }

    public void SetLocation(Vector2 loc)
    {
        print($"Setting location for {name} to {loc}");
        transform.position = loc;
    }

    public virtual void Face(FaceDirection dir)
    {
    }

    /// <summary>
    /// Updates the base stats
    /// </summary>
    protected virtual void UpdateBaseStats()
    {
        baseStats = new Stats(10, 5, 1, 1, 1, 5, 1, 0, 1, 1);
    }
}
