using Assets.Scripts.databases.game.shops;
using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.dialogue;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using Assets.Scripts.quest;
using Assets.Scripts.saving;
using Assets.Scripts.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public ShopInterface ShopInterface { private set; get; }
    private ShopDatabase shopDatabase;

    private List<Quest> questList = new List<Quest>();

    public override void Initiate()
    {
        base.Initiate();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);

        shopDatabase = GetComponent<ShopDatabase>();
        ShopInterface = MainCanvas.GetComponentInChildren<ShopInterface>();
        ShopInterface.SetActive(false);

        InitializeQuests();

        if (player == null)
            player = FindObjectOfType<Player>();
    }

    private void InitializeQuests()
    {
        IEnumerable<Type> quests = Utilities.GetAssembliesOfType(typeof(Quest));
        foreach(var q in quests)
        {
            if (!q.GetTypeInfo().IsAbstract)
            {
                Quest quest = (Quest)Activator.CreateInstance(q);
                questList.Add(quest.Initialize());
                quest.Load();
            }
        }

        for(int i = 0; i < questList.Count(); i++)
        {
            print(i + " quest: " + questList[i].Name + " " + questList[i].Id + " stage: " + questList[i].Stage);
        }

        questList.OrderBy(q => q.Id);
    }

    public Quest GetQuestByType(Type t)
    {
        return questList.Where(q => q.GetType() == t).FirstOrDefault();
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
        GameLoader.SaveGame();
        PlayerPrefs.Save();
    }

    internal void LoadGame()
    {
        int loadedScene = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "savedscene"));
        SceneManager.LoadScene(loadedScene == 0 ? 2 : loadedScene);
        GameLoader.LoadGame();
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
}
