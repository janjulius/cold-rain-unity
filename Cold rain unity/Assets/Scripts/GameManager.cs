using Assets.Scripts.databases.game.shops;
using Assets.Scripts.dialogue;
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
using static Assets.Scripts.managers.WorldStateManager;

public class GameManager : Node
{
    public GameObject MainCanvas;
    public GameObject EventSystem;
    public DialogueUIHandler DialogeUIHandler;
    public DialogueHandler DialogueHandler;
    public Player player;
    public GameObject groundItemPrefab;
    public GameLoader GameLoader;
    public SkillingInterfaceManager skillingInterfaceManager;

    public ShopInterface ShopInterface { private set; get; }
    private ShopDatabase shopDatabase;

    private List<Quest> questList = new List<Quest>();
    public QuestRequestInterface QuestRequestInterface { private set; get; }

    private WorldStateManager worldStateManager;

    [SerializeField] public int gameTime { private set; get; }
    [SerializeField] public int day { private set; get; } = 0;
    /// <summary>
    /// The amount of seconds delay when the time gets updated again
    /// </summary>
    private int UpdateTimeDelay = 1;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI DayText; 

    public override void Initiate()
    {
        base.Initiate();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);

        shopDatabase = GetComponent<ShopDatabase>();
        ShopInterface = MainCanvas.GetComponentInChildren<ShopInterface>();
        ShopInterface.SetActive(false);

        QuestRequestInterface = MainCanvas.GetComponentInChildren<QuestRequestInterface>();
        QuestRequestInterface.SetActive(false);

        worldStateManager = GetComponent<WorldStateManager>();

        InitializeQuests();

        SetDayText();
        InvokeRepeating("UpdateClock", UpdateTimeDelay, UpdateTimeDelay);
        UpdateClock();

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
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "day"), day);
        PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsKey(this, "time"), gameTime);

        GameLoader.SaveGame();
        PlayerPrefs.Save();
    }

    internal void LoadGame()
    {
        int loadedScene = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "savedscene"));
        SceneManager.LoadScene(loadedScene == 0 ? 2 : loadedScene);
        questList.ForEach(q => q.Load());

        //time and day
        day = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "day"), 0);
        gameTime = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "time"), 0);

        GameLoader.LoadGame();
    }

    internal void SetWorldState(int id, int state)
    {
        worldStateManager[id] = new WorldState(state);
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

    #region Clock/time/day

    public void UpdateClock()
    {
        gameTime += UpdateTimeDelay * 5;
        SetClockText();
        if (gameTime > 1440)
        {
            gameTime = 0;
            day++;
            SetDayText();
        }
    }

    private void SetClockText()
    {
        int hrs = (int)gameTime / 60;
        int mins = (int)gameTime - (hrs * 60);
        TimeText.text = $"{(hrs >= 24 ? "00" : hrs.ToString())}:{(mins < 10 ? "0" : "")}{mins}";
    }

    private void SetDayText()
    {
        DayText.text = $"Day {day}";
    }

    internal void SetTime(int time)
    {
        gameTime = time;
        SetClockText();
    }

    internal void SetDay(int day)
    {
        this.day = day;
        SetDayText();
    }

    internal void IncreaseTime(int time)
    {
        int newTime = gameTime + time;
        if(newTime > 1440)
        {
            SetDay(day + (int)Mathf.Floor(time / 1440));
            newTime -= 1440;
        }
        SetTime(newTime);
    }

    #endregion

}
