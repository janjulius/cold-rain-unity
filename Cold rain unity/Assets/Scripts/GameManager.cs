using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.dialogue;
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

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);

        if(player == null)
            player = FindObjectOfType<Player>();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
