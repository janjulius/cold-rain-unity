using Assets.Scripts.item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.container
{
    struct Container : SavingModule
    {
        private Item[] items;

        private int capacity;

        public Container(int capacity)
        {
            this.capacity = capacity;
            this.items = new Item[capacity];
        }

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
