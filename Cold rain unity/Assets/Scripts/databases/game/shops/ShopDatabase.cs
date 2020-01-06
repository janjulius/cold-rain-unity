using Assets.Scripts.container;
using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.databases.game.shops
{
    public class ShopDatabase : CRDatabase
    {
        ItemDatabase itemDb;

        public override void Initiate()
        {
            CallSelf = false;
            base.Initiate();
        }

        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building shop database...");
            itemDb = GetComponent<ItemDatabase>();

            items = new List<DbElement>()
            {
                new Shop(0, "TestShop", new Container(new Item[] { itemDb.GetItem(3, 10), itemDb.GetItem(2, 10) })),
            };
        }

        public Shop GetShop(int id)
        {
            return items.Where(i => i.Id == id).FirstOrDefault() as Shop;
        }
    }
}
