using Assets.Scripts.databases.game.shops;
using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.dialogue;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject EventSystem;
    public DialogueUIHandler DialogeUIHandler;
    public DialogueHandler DialogueHandler;
    public Player player;
    public GameObject groundItemPrefab;

    public ShopInterface ShopInterface { private set; get; }
    private ShopDatabase shopDatabase;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);

        shopDatabase = GetComponent<ShopDatabase>();
        ShopInterface = MainCanvas.GetComponentInChildren<ShopInterface>();
        ShopInterface.SetActive(false);

        if(player == null)
            player = FindObjectOfType<Player>();
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
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
