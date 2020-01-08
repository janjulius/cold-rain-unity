using System;
using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.gameinterfaces.navigator;
using Assets.Scripts.item;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.player.Equipment.visual;
using Assets.Scripts.stats;
using Assets.Scripts.styles.hairstyles;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    private bool singleLoad = false;

    private Appearance appearance;

    #region Information

    public bool IsInShop = false;

    #endregion
    
    #region Interfaces and containers

    public Container InventoryContainer { private set; get; }
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
        DontDestroyOnLoad(this);
        SetLayer((int)UnityLayers.PLAYER);

        GetReferences();
        GetOtherReferences();

        LoadInterfaces();

        LoadAppearance();

        InventoryContainer.Add(0, 1);
        InventoryContainer.Add(2, 1);
        InventoryContainer.Add(79, 1);
        InventoryContainer.Add(4, 1);
        InventoryContainer.Add(384, 1000);
        SetLocation(SpawnPosition);
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

    protected override void EntityUpdate()
    {
        base.EntityUpdate();
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        if (!IsMoving || !IsLocked)
            CheckMovementKeys();
        
        CheckInterfaceToggleKeys();
        CheckOtherKeys();
    }

    private void CheckMovementKeys()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 offset = new Vector2(transform.position.x - Constants.TILE_SIZE, transform.position.y);
            Face(FaceDirection.LEFT);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 offset = new Vector2(transform.position.x + Constants.TILE_SIZE, transform.position.y);
            Face(FaceDirection.RIGHT);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y + Constants.TILE_SIZE);
            Face(FaceDirection.UP);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y - Constants.TILE_SIZE);
            Face(FaceDirection.DOWN);
            SetDestination(offset);
        }
    }

    public void CheckInterfaceToggleKeys()
    {
        //TODO REFRESH INVENTORY ON OPENING, NOT ON BUTTON PRESS
        if (Input.GetKeyDown(KeyCode.I))
            inventoryInterface.ToggleActive();
        if (Input.GetKeyDown(KeyCode.Tab))
            navigatorDisplay.ToggleActive();
    }

    public void CheckOtherKeys()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
            if (facingEntity != null)
                facingEntity.Interact(this);
            else if (facingInteractable != null)
                facingInteractable.Interact(this);
    }

    public override void Face(FaceDirection dir)
    {
        base.Face(dir);
        animator?.SetInteger("FaceDir", (int)dir);
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
        if (!singleLoad)
        {
            LoadNavigator();
            LoadInventory();
            LoadSkillsInterface();
            LoadEquipmentInterface();
        }
        singleLoad = true;
    }

    private void LoadNavigator()
    {
        navigatorDisplay = Camera.main.GetComponent<GameManager>().MainCanvas.GetComponentInChildren<NavigatorInterface>();
    }

    private void LoadInventory()
    {
        inventoryInterface = gameManager.MainCanvas.GetComponentInChildren<Inventory>();
        InventoryContainer = new Container(Constants.INVENTORY_SIZE, inventoryInterface);
        inventoryInterface.Create(this);
        InventoryContainer.Refresh();
        inventoryInterface.ToggleActive();
    }

    private void LoadSkillsInterface()
    {
        skillsInterface = gameManager.MainCanvas.GetComponentInChildren<SkillsInterface>();
        skillsInterface.Create(this);
        skillsInterface.Refresh();
        skillsInterface.ToggleActive();
    }

    private void LoadEquipmentInterface()
    {
        equipmentInterface = gameManager.MainCanvas.GetComponentInChildren<EquipmentInterface>();
        equipmentInterface.Create(this);
        equipmentInterface.Refresh();
        equipmentInterface.ToggleActive();
    }

    public void RefreshEquipmentInterface(Stats itemStats)
    {
        UpdateStats(itemStats);
        equipmentInterface.Refresh(equipment, stats);
    }

    public void SetEquipmentAppearance(EquipmentType eq, Item item)
    {
        appearance.SetEquipment(eq, item, FaceDirection);
    }
    
    internal void LoadIntoScene(int sceneId, Vector2 endLocation)
    {
        SceneManager.LoadScene(sceneId);
        SetLocation(endLocation);
    }

    internal void GiveItem(int id, int amount)
    {
        Item item = itemDatabase.GetItem(id);
        if (item.Stackable)
        {
            item.SetAmount(amount);

            if (!InventoryContainer.Add(item))
                gameManager.CreateGroundItem(item, transform);
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                if (!InventoryContainer.Add(item))
                {
                    gameManager.CreateGroundItem(item, transform);
                }
            }
        }
    }
}
