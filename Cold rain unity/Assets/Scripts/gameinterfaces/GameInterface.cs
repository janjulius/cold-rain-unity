using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameInterface : Node
{
    protected Player player;
    
    public bool ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        return gameObject.activeSelf;
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }

    public abstract void Create(Player player);
    public abstract void Refresh();
}
