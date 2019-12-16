using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Node
{
    protected Skills skills;

    private void Awake()
    {
        Initiate();
    }

    public override void Initiate()
    {
        base.Initiate();
        skills = gameObject.AddComponent<Skills>();
    }
}
