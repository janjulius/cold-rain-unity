using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject EventSystem;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(MainCanvas);
        DontDestroyOnLoad(EventSystem);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
