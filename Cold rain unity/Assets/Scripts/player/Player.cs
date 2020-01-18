using System;
using Assets.Scripts.activity.minigame;
using Assets.Scripts.container;
using Assets.Scripts.contants;
using Assets.Scripts.databases;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.gameinterfaces.navigator;
using Assets.Scripts.item;
using Assets.Scripts.managers;
using Assets.Scripts.math;
using Assets.Scripts.player.Equipment;
using Assets.Scripts.player.Equipment.visual;
using Assets.Scripts.saving;
using Assets.Scripts.stats;
using Assets.Scripts.styles.hairstyles;
using Assets.Scripts.util;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity, SavingModule
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
    private ActivityManager ActivityManager;

    #endregion

    #region Saving

    //This is to ensure the player will not be sitting in an immovable object
    private bool savingNewScene = false;

    #endregion

    #region playerinfo
    public Combatstate Combatstate { get; private set; }
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
        Face(SpawnFaceDirection);

        InventoryContainer.Add(0, 1);
        InventoryContainer.Add(2, 1);
        InventoryContainer.Add(79, 1);
        InventoryContainer.Add(4, 1);
        InventoryContainer.Add(384, 1000);
        InventoryContainer.Add(192, 3);
        InventoryContainer.Add(177, 10);
        //SetLocation(SpawnPosition);
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
        ActivityManager = gameManager.ActivitiesObject.GetComponent<ActivityManager>();
    }

    #endregion

    protected override void EntityUpdate()
    {
        base.EntityUpdate();
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        
        if (!IsMoving && !IsLocked)
            CheckMovementKeys();
        
        CheckInterfaceToggleKeys();
        if (!IsLocked)
            CheckOtherKeys();
    }


    private void CheckMovementKeys()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 offset = new Vector2(transform.position.x - Constants.TILE_SIZE, transform.position.y);
            Face(FaceDirection.LEFT);
            animator?.SetInteger("KeyCode", (int)3);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 offset = new Vector2(transform.position.x + Constants.TILE_SIZE, transform.position.y);
            Face(FaceDirection.RIGHT);
            animator?.SetInteger("KeyCode", (int)1);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y + Constants.TILE_SIZE);
            Face(FaceDirection.UP);
            animator?.SetInteger("KeyCode", (int)2);
            SetDestination(offset);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y - Constants.TILE_SIZE);
            Face(FaceDirection.DOWN);
            animator?.SetInteger("KeyCode", (int)0);
            SetDestination(offset);
        }
        else
        {
            animator?.SetInteger("KeyCode", (int)-1);
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Constants.DEVELOPER_MODE)
            {
                GameConsole.Instance.SendDevMessage("Saving the game...");
                gameManager.SaveGame();
                GameConsole.Instance.SendDevMessage("Game was saved.");
            }
        }
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

    #region Quests
    internal void SetQuestStage(int id, int stage)
    {
        gameManager.SetQuestStage(id, stage);
    }

    internal int GetQuestStage(int id)
    {
        return gameManager.GetQuestStage(id);
    }
    #endregion


    internal void LoadIntoScene(int sceneId, Vector2 endLocation)
    {
        savingNewScene = true;
        gameManager.SaveGame();
        SceneManager.LoadScene(sceneId);
        SetLocation(endLocation);
    }

    public void StartActivity(Activity activity, bool useClock)
    {
        ActivityManager.Activity = activity;
        activity.StartActivity(ActivityManager, this, useClock);
    }
    
    public void Load()
    {
        Vector2 loadPos = new Vector2(PlayerPrefs.GetFloat(SavingHelper.ConstructPlayerPrefsKey(this, "posx")),
                            PlayerPrefs.GetFloat(SavingHelper.ConstructPlayerPrefsKey(this, "posy")));
        SpawnPosition = loadPos;
        SpawnFaceDirection = (FaceDirection)PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "facedir"), 0);
        Combatstate = (Combatstate)PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "combatstate"), 0);
    }

    public void Save()
    {
        Vector2 savingPlayerPos = new Vector2(transform.position.x, transform.position.y);
        savingPlayerPos = MathUtilities.RoundToNearestHalves(savingPlayerPos);
        if (savingNewScene)
        {
            if (FaceDirection == FaceDirection.DOWN)
                savingPlayerPos.y += Constants.TILE_SIZE;
            else if (FaceDirection == FaceDirection.UP)
                savingPlayerPos.y -= Constants.TILE_SIZE;
            else if (FaceDirection == FaceDirection.LEFT)
                savingPlayerPos.x += Constants.TILE_SIZE;
            else
                savingPlayerPos.x -= Constants.TILE_SIZE;
        }
        
        PlayerPrefs.SetFloat(SavingHelper.ConstructPlayerPrefsKey(this, "posx"), savingPlayerPos.x);
        PlayerPrefs.SetFloat(SavingHelper.ConstructPlayerPrefsKey(this, "posy"), savingPlayerPos.y);
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "facedir"), (int)FaceDirection);
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "combatstate"), (int)Combatstate);
        savingNewScene = false;
    }
}
