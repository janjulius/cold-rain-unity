using Assets.Scripts.databases.game.shops;
using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.dialogue;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using Assets.Scripts.saving;
using System;
using System.Collections;
using System.Collections.Generic;
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

    public override void Initiate()
    {
        base.Initiate();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);

        shopDatabase = GetComponent<ShopDatabase>();
        ShopInterface = MainCanvas.GetComponentInChildren<ShopInterface>();
        ShopInterface.SetActive(false); 

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
        GameLoader.SaveGame();
        PlayerPrefs.Save();
    }

    internal void LoadGame()
    {
        int loadedScene = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsKey(this, "savedscene"));
        SceneManager.LoadScene(loadedScene == 0 ? 2 : loadedScene);
        GameLoader.LoadGame();
    }
}
