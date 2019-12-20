using Assets.Scripts.item;
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

        public Container(int capacity)
        {
            this.capacity = capacity;
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
                    return true;
                }
            }
            return false;
        }

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
