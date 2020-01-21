using Assets.Scripts.databases.game.shops;
using Assets.Scripts.dialogue;
using Assets.Scripts.game.time;
using Assets.Scripts.gameinterfaces.dialogue;
using Assets.Scripts.gameinterfaces.quest;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using Assets.Scripts.managers;
using Assets.Scripts.managers.skilling;
using Assets.Scripts.quest;
using Assets.Scripts.saving;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Node
{
    public GameObject MainCanvas;
    public GameObject EventSystem;
    public DialogueUIHandler DialogeUIHandler;
    public DialogueHandler DialogueHandler;
    public Player player;
    public GameObject groundItemPrefab;
    public GameLoader GameLoader;
    public GameObject ActivitiesObject;
    public SkillingInterfaceManager skillingInterfaceManager;

    public ShopInterface ShopInterface { private set; get; }
    private ShopDatabase shopDatabase;

    private List<Quest> questList = new List<Quest>();
    public QuestRequestInterface QuestRequestInterface { private set; get; }
    
    public ScreenTransitioner screenTransitioner;

    public GameClock GameClock;
    
    public override void Initiate()
    {
        base.Initiate();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);
        DontDestroyOnLoad(screenTransitioner);

        shopDatabase = GetComponent<ShopDatabase>();
        ShopInterface = MainCanvas.GetComponentInChildren<ShopInterface>();
        ShopInterface.SetActive(false);

        QuestRequestInterface = MainCanvas.GetComponentInChildren<QuestRequestInterface>();
        QuestRequestInterface.SetActive(false);
        
        InitializeQuests();

        GameClock.StartClock();
        
        if (player == null)
            player = FindObjectOfType<Player>();
    }


    public override void DelayedStartInitiate()
    {
        base.DelayedStartInitiate();
        LoadGame();
    }

    public void CreateGroundItem(Item item, Transform pos)
    {
        GameObject gItem = Instantiate(groundItemPrefab, new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
        gItem.GetComponent<GroundItem>().Create(item, player);
    }

    public void LoadShop(int id)
    {
        ShopInterface.SetActive(true);
        ShopInterface.Load(shopDatabase.GetShop(id), player);
    }

    internal void SaveGame()
    {
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "savedscene"), SceneManager.GetActiveScene().buildIndex);
        questList.ForEach(q => q.Save());

        //time and day
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "day"), GameClock.Day);
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "time"), GameClock.GameTime);

        GameLoader.SaveGame();
        PlayerPrefs.Save();
    }

    internal void LoadGame()
    {
        int loadedScene = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "savedscene"));
        SceneManager.LoadScene(loadedScene == 1 ? 2 : loadedScene);
        questList.ForEach(q => q.Load());

        //time and day
        GameClock.SetDay(PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "day"), 0));
        GameClock.SetTime(PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "time"), 0));

        GameLoader.LoadGame();
    }

    internal void SetWorldState(int id, int state)
    {
        WorldStateManager.Instance.SetState(id, state);
    }

    #region Quests
    private void InitializeQuests()
    {
        IEnumerable<Type> quests = Utilities.GetAssembliesOfType(typeof(Quest));
        foreach (var q in quests)
        {
            if (!q.GetTypeInfo().IsAbstract)
            {
                Quest quest = (Quest)Activator.CreateInstance(q);
                questList.Add(quest.Initialize());
                quest.Load();
            }
        }

        questList.OrderBy(q => q.Id);
    }

    public Quest GetQuestByType(Type t)
    {
        return questList.Where(q => q.GetType() == t).FirstOrDefault();
    }

    public Quest GetQuestById(int id)
    {
        return questList.Where(q => q.Id == id).FirstOrDefault();
    }

    internal void SetQuestStage(int id, int stage)
    {
        Quest quest = questList.Where(q => q.Id == id).FirstOrDefault();
        quest.SetStage(stage);
    }

    internal int GetQuestStage(int id)
    {
        return questList.Where(q => q.Id == id).FirstOrDefault().Stage;
    }

    internal void ProposeQuest(int id)
    {
        QuestRequestInterface.SetActive(true);
        QuestRequestInterface.Load(GetQuestById(id), player);
    }
    #endregion
    
    public void FadeScreen(float time)
    {
        StartCoroutine(screenTransitioner.FadeScreen(time));
    }

    public void FadeScreenWarp(float time, Player player, int SceneId, Vector2 endLocation)
    {
        StartCoroutine(screenTransitioner.FadeScreenWarp(time, player, SceneId, endLocation));
    }
}
