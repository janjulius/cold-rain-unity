using Assets.Scripts.stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Node
{
    protected Skills skills;

    protected Stats stats;

    private Stats baseStats;
    private Stats bonusStats;

    protected int hitPoints;
    protected int energy;

    #region MovingVariables

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timeToReachTarget;
    private float timeM;

    #endregion

    private void Start()
    {
        Initiate();
    }

    public override void Initiate()
    {
        base.Initiate();
        baseStats = gameObject.AddComponent<Stats>();
        UpdateBaseStats();
        bonusStats = gameObject.AddComponent<Stats>();
        skills = gameObject.AddComponent<Skills>();
        UpdateStats();
    }

    public void Update()
    {
        EntityUpdate();
        timeM += Time.deltaTime / timeToReachTarget;
        transform.position = Vector2.Lerp(startPosition, targetPosition, timeM);
    }

    public virtual void EntityUpdate()
    {

    }

    private void UpdateStats()
    {
        stats = baseStats + bonusStats;
        timeToReachTarget = 1 / stats.Speed;
    }

    public void SetDestination(Vector2 loc)
    {
        timeM = 0;
        startPosition = transform.position;
        targetPosition = loc;
    }

    protected virtual void UpdateBaseStats()
    {
        baseStats = new Stats(10, 5, 1, 1, 1, 5, 1, 0, 1, 1);
    }
}
