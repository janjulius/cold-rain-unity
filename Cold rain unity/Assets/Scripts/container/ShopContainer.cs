using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.gameinterfaces.shop;
using Assets.Scripts.item;
using UnityEngine;

namespace Assets.Scripts.container
{
    public class ShopContainer : Container
    {
        public override void Refresh()
        {
            Camera.main.GetComponent<GameManager>().ShopInterface.Refresh();
        }

        public ShopContainer(params Item[] items) : base(items)
        {
            containerDisplay = Camera.main.GetComponent<GameManager>().ShopInterface;
        }

    }
}
