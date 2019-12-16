using Assets.Scripts.math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void Initiate()
    {
        base.Initiate();
        ProgressCalculator pc = new ProgressCalculator();
    }
}
