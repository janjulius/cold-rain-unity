using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterface : Node
{
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }
}
