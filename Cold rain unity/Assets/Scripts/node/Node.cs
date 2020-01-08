using Assets.Scripts.node;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Atom
{
    protected bool initiated = false;
    protected bool startInitiated = false;
    protected bool delayedStartInitiated = false;

    public void Awake()
    {
        Initiate();
    }

    public void Start()
    {
        StartInitiate();
        DelayedStartInitiate();
    }

    /// <summary>
    /// Mostly used for loading database and other things before the game can be started
    /// </summary>
    public override void Initiate()
    {
        if (!initiated)
        {
            initiated = true;
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Used for initialising objects or entities
    /// </summary>
    public override void StartInitiate()
    {
        if (!startInitiated)
        {
            startInitiated = true;
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Used for initialising objects or entities after StartInitiate
    /// </summary>
    public override void DelayedStartInitiate()
    {
        if (!delayedStartInitiated)
        {
            delayedStartInitiated = true;
        }
        else
        {
            return;
        }
    }

    public void SetLayer(int layer)
    {
        gameObject.layer = layer;
    }
}
