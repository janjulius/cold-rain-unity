using Assets.Scripts.container;
using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    private Container inventory = new Container(50);


    public override void Initiate()
    {
        base.Initiate();
        inventory.Add(ItemDatabase.GetItem(0), 1);
        print(inventory);
    }

    public void Update()
    {
    }
}
