using Assets.Scripts.container;
using Assets.Scripts.contants;
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
        transform.position = new Vector2(2, 2);
    }


    public override void EntityUpdate()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        if (!IsMoving)
            CheckMovementKeys();
    }

    private void CheckMovementKeys()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 offset = new Vector2(transform.position.x - Constants.TILE_SIZE, transform.position.y);
            SetDestination(offset);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 offset = new Vector2(transform.position.x + Constants.TILE_SIZE, transform.position.y);
            SetDestination(offset);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y + Constants.TILE_SIZE);
            SetDestination(offset);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y - Constants.TILE_SIZE);
            SetDestination(offset);
        }
    }
}
