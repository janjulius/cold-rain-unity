using Assets.Scripts.node;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Atom
{
    public void Awake()
    {
        Initiate();
    }

    public void Start()
    {
        StartInitiate();
    }

    /// <summary>
    /// Mostly used for loading database and other things before the game can be started
    /// </summary>
    public override void Initiate()
    {

    }

    /// <summary>
    /// Used for initialising objects or entities
    /// </summary>
    public override void StartInitiate()
    {

    }
}
