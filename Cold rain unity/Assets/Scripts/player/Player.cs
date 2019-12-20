using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.math;
using Assets.Scripts.player.Equipment.visual;
using Assets.Scripts.styles.hairstyles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    private Container inventoryContainer = new Container(Constants.INVENTORY_SIZE);

    private Inventory inventoryDisplay;

    private Appearance appearance;

    #region Database References

    ItemDatabase itemDatabase;
    HairDatabase hairDatabase;

    #endregion

    public override void StartInitiate()
    {
        base.StartInitiate();

        GetReferences();

        LoadAppearance();
        

        inventoryContainer.Add(itemDatabase.GetItem(0), 1);
        inventoryContainer.Add(itemDatabase.GetItem(0), 1);
        inventoryDisplay = Camera.main.GetComponent<GameManager>().MainCanvas.GetComponentInChildren<Inventory>();
        print(inventoryDisplay);
        inventoryDisplay.Refresh(inventoryContainer);
    }

    #region References

    private void GetReferences()
    {
        itemDatabase = Camera.main.GetComponent<ItemDatabase>();
        hairDatabase = Camera.main.GetComponent<HairDatabase>();
    }

    #endregion

    public override void EntityUpdate()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        if (!IsMoving)
            CheckMovementKeys();

        CheckInterfaceToggleKeys();
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

    public void CheckInterfaceToggleKeys()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryDisplay.gameObject.SetActive(!inventoryDisplay.gameObject.activeSelf);
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
