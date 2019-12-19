using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.math;
using Assets.Scripts.player.Equipment.visual;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    private Container inventory = new Container(50);

    private Appearance appearance;
    
    public override void Initiate()
    {
        base.Initiate();
        LoadAppearance();
        inventory.Add(ItemDatabase.GetItem(0), 1);
        print(inventory);
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
            Face(FaceDirection.LEFT);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 offset = new Vector2(transform.position.x + Constants.TILE_SIZE, transform.position.y);
            SetDestination(offset);
            Face(FaceDirection.RIGHT);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y + Constants.TILE_SIZE);
            SetDestination(offset);
            Face(FaceDirection.UP);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y - Constants.TILE_SIZE);
            SetDestination(offset);
            Face(FaceDirection.DOWN);
        }
    }

    public override void Face(FaceDirection dir)
    {
        base.Face(dir);
        appearance.UpdateAppearance(dir);
    }

    private void LoadAppearance()
    {
        appearance = GetComponentInChildren<Appearance>();
        appearance.Initiate();
    }
}
