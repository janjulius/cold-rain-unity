﻿using Assets.Scripts.container;
using Assets.Scripts.databases;
using Assets.Scripts.saving;
using System;
using UnityEngine;

namespace Assets.Scripts.shops
{
    public class Shop : DbElement, SavingModule
    {
        public string Title { private set; get; }
        public Container Container { private set; get; }
        public float BuyMultiplier { private set; get; } = 1.3f;
        public float SellMultiplier { private set; get; } = 0.8f;

        public Shop(int id, string title, Container container)
        {
            this.Id = id;
            this.Title = title;
            this.Container = container;
            Load();
        }

        public Shop(int id, string title, Container container, float buyMultiplier, float sellMultiplier) : this(id, title, container)
        {
            this.BuyMultiplier = BuyMultiplier;
            this.SellMultiplier = SellMultiplier;
        }

        public int GetShopBuyPrice(int val) => (int)Math.Floor(val * BuyMultiplier);
        public int GetShopSellPrice(int val) => (int)Math.Floor(val * SellMultiplier);

        public void DepleteItem(int id, int amount)
        {
            Container.Remove(id, amount);
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

        public override string ToString()
        {
            return base.ToString() + $"Id:{Id}, Title:{Title}, Multipliers: B:x{BuyMultiplier} S:x{SellMultiplier}";
        }
    }
}
