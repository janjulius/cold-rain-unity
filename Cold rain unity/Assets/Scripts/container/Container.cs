using Assets.Scripts.databases;
using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.container
{
    /// <summary>
    /// Repersents a container which can hold items
    /// </summary>
    public class Container : SavingModule
    {
        /// <summary>
        /// The items in the container
        /// </summary>
        private Item[] items;

        /// <summary>
        /// The capacity of the container
        /// </summary>
        private int capacity;

        /// <summary>
        /// the display for the container
        /// </summary>
        private ContainerDisplay containerDisplay;

        /// <summary>
        /// Itemdatabase
        /// </summary>
        private ItemDatabase itemDatabase = null;

        public Container(int capacity, ContainerDisplay containerDisplay)
        {
            this.capacity = capacity;
            this.containerDisplay = containerDisplay;
            this.items = new Item[capacity];
            itemDatabase = Camera.main.GetComponent<ItemDatabase>();
        }

        /// <summary>
        /// construct a container with set items
        /// </summary>
        /// <param name="items"></param>
        public Container(params Item[] items)
        {
            this.containerDisplay = null;
            this.capacity = items.Length;
            this.items = items;
            itemDatabase = Camera.main.GetComponent<ItemDatabase>();
        }

        /// <summary>
        /// Add an item to the container
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="quantity">The quantity</param>
        /// <returns></returns>
        public bool Add(Item item, int quantity)
        {
            for(int i = 0; i < capacity; i++)
            {
                if(items[i] == null)
                {
                    items[i] = item;
                    if (items[i].Amount == 0)
                        items[i].Amount = 1;
                    Refresh();
                    return true;
                }
            }
            return false;
        }

        public bool Add(Item item)
        {
            if (!HasFreeSlots())
                return false;

            for (int i = 0; i < items.Length; i++)
            {
                if(items[i] == null)
                {
                    items[i] = item;
                    Refresh();
                    return true;
                }
            }
            return false;
        }

        public bool Add(int id, int amount)
        {
            Item item = itemDatabase.GetItem(id);

            if (item.Stackable)
            {
                item.SetAmount(amount);
                Refresh();
                return Add(item);
            }
            else
            {
                bool result = false;
                for(int i = 0; i < amount; i++)
                {
                    item.SetAmount(1);
                    result = Add(item);
                }
                Refresh();
                return result;
            }
        }

        //public bool Add(int id, int amount)
        //{
        //    Item item = itemDatabase.GetItem(id);
        //     
        //   
        //}
        
        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool Remove(Item item, int quantity)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (items[i] == null)
                    continue;
                if (items[i].Id == item.Id)
                {
                    if (items[i].Amount < quantity) //if amount of item is less than quantity
                    {
                        return false;
                    }
                    else
                    {
                        items[i].Amount -= quantity;
                        if(items[i].Amount <= 0)
                            items[i] = null;
                        Refresh();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// removes an amount of given id 
        /// note: removes items regardless if the player has all the required items
        /// use: <see cref="GetAmount(int)"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Remove(int id, int amount)
        {
            int amnt = amount;
            for (int it = 0; it < items.Length; it++)
            {
                if(items[it] != null)
                {
                    if(items[it].Id == id)
                    {
                        if (items[it].Stackable)
                        {
                            items[it].Amount = items[it].Amount - amount;
                            if (items[it].Amount <= 0)
                                items[it] = null;
                            Refresh();
                            return true;
                        }
                        else
                        {
                            items[it] = null;
                            amnt--;
                            if (amnt == 0)
                            {
                                Refresh();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// returns the amount of item with given id in the container
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetAmount(int id)
        {
            int total = 0;
            foreach(Item it in items)
            {
                if(it != null)
                {
                    if(it.Id == id)
                    {
                        total += it.Amount;
                        if (!it.Stackable)
                            break;
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Item item) => Remove(item, 1);
        
        /// <summary>
        /// True if the item is present in the container
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ContainsItem(Item item)
        {
            foreach (Item it in items)
            {
                if (it != null && it.Id == item.Id)
                {
                    if (it.Id == item.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// returns true if the container contains an item of given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(int id)
        {
            foreach(Item it in items)
                if(it != null)
                    if (it.Id == id)
                        return true;
            return false;
        }

        /// <summary>
        /// returns the first item of the id given, null if not found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetItem(int id)
        {
            foreach (Item it in items)
                if (it != null)
                    if (it.Id == id)
                        return it;
            return null;
        }

        /// <summary>
        /// Refreshes the container
        /// </summary>
        public void Refresh()
        {
            if (containerDisplay != null)
                containerDisplay.Refresh(this);
            else
                CrLogger.Log(this, "Tried to refresh container, but the display is null", CrLogger.LogType.WARNING);
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the amount of free slots in the container
        /// </summary>
        /// <returns></returns>
        public int GetFreeSlots()
        {
            int r = 0;
            foreach(Item i in items)
            {
                if (i == null)
                    r++;
            }
            r = Math.Abs(r - capacity);
            return r;
        }

        public bool HasFreeSlots() => GetFreeSlots() <= 0;

        /// <summary>
        /// Gets the items in this container
        /// </summary>
        /// <returns></returns>
        public Item[] GetItems()
        {
            return items;
        }

        public override string ToString()
        {
            StringBuilder r = new StringBuilder();
            r.Append($"Container contains size of: {GetFreeSlots()}/{items.Count()}");
            for(int i = 0; i < items.Count(); i++)
            {
                if(items[i] != null)
                {
                    r.Append($"\nSlot {i}: {items[i].Name} ({items[i].Id})");
                }
            }
            return r.ToString();
        }
    }
}
