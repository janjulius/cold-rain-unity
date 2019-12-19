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

    public override void Initiate()
    {

    }

    public override void StartInitiate()
    {

    }
}
