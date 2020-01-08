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
                new Shop(1, "HuntingShop", new Container(new Item[] { itemDb.GetItem(116, 100), itemDb.GetItem(173, 5),
                                                                        itemDb.GetItem(174, 5), itemDb.GetItem(175, 50),
                                                                        itemDb.GetItem(176, 1)})),
                new Shop(2,"FishingShop", new Container(new Item[] { itemDb.GetItem(221, 1), itemDb.GetItem(222, 1),
                                                                        itemDb.GetItem(223, 1), itemDb.GetItem(224, 1),
                                                                        itemDb.GetItem(225, 1), itemDb.GetItem(226, 1),
                                                                        itemDb.GetItem(227, 1), itemDb.GetItem(228, 1),
                                                                        itemDb.GetItem(229, 1), itemDb.GetItem(230, 1),
                                                                        itemDb.GetItem(231, 1), itemDb.GetItem(232, 1),
                                                                        itemDb.GetItem(233, 1), itemDb.GetItem(234, 1),
                                                                        itemDb.GetItem(235, 1), itemDb.GetItem(236, 1),
                                                                        itemDb.GetItem(237, 1), itemDb.GetItem(238, 1),
                                                                        itemDb.GetItem(239, 1), itemDb.GetItem(240, 1),
                                                                        itemDb.GetItem(241, 1), itemDb.GetItem(242, 1),
                                                                        itemDb.GetItem(243, 1), itemDb.GetItem(244, 1),
                                                                        itemDb.GetItem(245, 1000), itemDb.GetItem(246, 2)})),
                new Shop(3, "CropShop", new Container(new Item[] { itemDb.GetItem(259, 1), itemDb.GetItem(260, 1),
                                                                        itemDb.GetItem(262, 1), itemDb.GetItem(261, 30),
                                                                        itemDb.GetItem(263, 1), itemDb.GetItem(264, 30),
                                                                        itemDb.GetItem(265, 1), itemDb.GetItem(266, 30),})),
                new Shop(4, "LivestockShop", new Container(new Item[] { itemDb.GetItem(272, 50), itemDb.GetItem(273, 10),
                                                                        itemDb.GetItem(274, 1) })),
            };
        }

        public Shop GetShop(int id)
        {
            return items.Where(i => i.Id == id).FirstOrDefault() as Shop;
        }
    }
}
