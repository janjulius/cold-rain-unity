using Assets.Scripts.databases;
using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.game.consumables
{
    public class ConsumableProperties : Node
    {
        private readonly int healing;
        private readonly Item newItem;

        private ItemDatabase itemDatabase;

        public override void Initiate()
        {
            base.Initiate();
            itemDatabase = Camera.main.GetComponent<GameManager>().GetComponent<ItemDatabase>();
        }
        
        public ConsumableProperties(int healing, int newItem)
        {
            this.healing = healing;
            if (newItem == -1)
                this.newItem = null;
            else
                this.newItem = itemDatabase.GetItem(newItem);
        }
    }
}
