using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.gameinterfaces.navigator;
using Assets.Scripts.item;
using Assets.Scripts.math;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.player.Equipment.visual;
using Assets.Scripts.styles.hairstyles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    private Appearance appearance;
    
    #region Interfaces and containers

    private Container inventoryContainer;
    private Inventory inventoryInterface;
    private EquipmentInterface equipmentInterface;
    private SkillsInterface skillsInterface;
    private NavigatorInterface navigatorDisplay;

    #endregion

    #region Database References

    ItemDatabase itemDatabase;
    HairDatabase hairDatabase;

    #endregion

    #region Other References

    private GameManager gameManager;

    #endregion


    public override void StartInitiate()
    {
        base.StartInitiate();

        GetReferences();
        GetOtherReferences();
        
        LoadInterfaces();

        LoadAppearance();
        
        inventoryContainer.Add(itemDatabase.GetItem(0), 1);
        inventoryContainer.Add(itemDatabase.GetItem(0), 1);
    }


    #region References

    private void GetReferences()
    {
        itemDatabase = Camera.main.GetComponent<ItemDatabase>();
        hairDatabase = Camera.main.GetComponent<HairDatabase>();
    }

    private void GetOtherReferences()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
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
            inventoryInterface.ToggleActive();
        if (Input.GetKeyDown(KeyCode.Tab))
            navigatorDisplay.ToggleActive();
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

    private void LoadEquipment()
    {
        equipment = GetComponent<EquipmentSlots>();
    }

    private void LoadInterfaces()
    {
        LoadNavigator();
        LoadInventory();
        LoadSkillsInterface();
        LoadEquipmentInterface();
    }

    private void LoadNavigator()
    {
        navigatorDisplay = Camera.main.GetComponent<GameManager>().MainCanvas.GetComponentInChildren<NavigatorInterface>();
    }

    private void LoadInventory()
    {
        inventoryInterface = gameManager.MainCanvas.GetComponentInChildren<Inventory>();
        inventoryContainer = new Container(Constants.INVENTORY_SIZE, inventoryInterface);
        inventoryContainer.Refresh();
        inventoryInterface.ToggleActive();
    }

    private void LoadSkillsInterface()
    {
        skillsInterface = gameManager.MainCanvas.GetComponentInChildren<SkillsInterface>();
        skillsInterface.Create(skills);
        skillsInterface.Refresh();
        skillsInterface.ToggleActive();
    }

    private void LoadEquipmentInterface()
    {
        equipmentInterface = gameManager.MainCanvas.GetComponentInChildren<EquipmentInterface>();
        equipmentInterface.Refresh(equipment, stats);
        equipmentInterface.ToggleActive();
    }
}
