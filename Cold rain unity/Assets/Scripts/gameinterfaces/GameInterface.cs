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

    public virtual void Create(Player player)
    {
        this.player = player;
    }

    public abstract void Create();
    public abstract void Refresh();
}
