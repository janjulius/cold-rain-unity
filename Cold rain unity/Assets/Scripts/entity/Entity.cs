using Assets.Scripts.stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Node
{
    protected Skills skills;

    protected Stats stats;

    private void Start()
    {
        Initiate();
    }

    public override void Initiate()
    {
        base.Initiate();
        skills = gameObject.AddComponent<Skills>();
        stats = gameObject.AddComponent<Stats>();
    }
}
