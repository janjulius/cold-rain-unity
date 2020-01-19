using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public SpriteRenderer head;

    public Color Pink;
    public Color Yellow;

    public int colorId = 1;

    void Update()
    {
        if (colorId == 1)
        {
            head.color = Pink;
        }
        else if(colorId == 2)
        {
            head.color = Yellow;
        }
    }

    public void ChangeHeadPink()
    {
        colorId = 1;
    }
    public void ChangeHeadYellow()
    {
        colorId = 2;
    }
}
