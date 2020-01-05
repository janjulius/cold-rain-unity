using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.container
{
    /// <summary>
    /// Repersents a container which can hold items
    /// </summary>
    public struct Container : SavingModule
    {
        /// <summary>
        /// The items in the container
        /// </summary>
        private Item[] items;

        /// <summary>
        /// The capacity of the container
        /// </summary>
        private int capacity;

        private ContainerDisplay containerDisplay;

        public Container(int capacity, ContainerDisplay containerDisplay)
        {
            this.capacity = capacity;
            this.containerDisplay = containerDisplay;
            this.items = new Item[capacity];
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
