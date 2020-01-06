using Assets.Scripts.container;
using Assets.Scripts.databases;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.shops
{
    public class Shop : DbElement, SavingModule
    {
        public string Title { private set; get; }
        public Container Container { private set; get; }

        public Shop(int id, string title, Container container)
        {
            this.Id = id;
            this.Title = title;
            this.Container = container;
            Load();
        }

        public void Load()
        {
            foreach (var i in Container.GetItems())
                i.Amount = PlayerPrefs.GetInt(SavingHelper.ConstructPlayerPrefsShopKey(this, Id, i.Id), i.Amount);
        }

        public void Save()
        {
            foreach (var i in Container.GetItems())
                PlayerPrefs.SetInt(SavingHelper.ConstructPlayerPrefsShopKey(this, Id, i.Id), i.Amount);
        }
    }
}
