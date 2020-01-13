using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.container;

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
                new Shop(0, "TestShop", new ShopContainer(new Item[] { itemDb.GetItem(3, 10), itemDb.GetItem(2, 10) })),
                new Shop(1, "Hunting Shop", new ShopContainer(new Item[] { itemDb.GetItem(116, 100), itemDb.GetItem(173, 5),
                                                                        itemDb.GetItem(174, 5), itemDb.GetItem(175, 50),
                                                                        itemDb.GetItem(176, 1)})),
                new Shop(2,"Fishing Shop", new ShopContainer(new Item[] { itemDb.GetItem(221, 1), itemDb.GetItem(222, 1),
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
                                                                        itemDb.GetItem(245, 1000), itemDb.GetItem(246, 2),
                                                                        itemDb.GetItem(247,2)})),
                new Shop(3, "Crop Shop", new ShopContainer(new Item[] { itemDb.GetItem(259, 1), itemDb.GetItem(260, 1),
                                                                        itemDb.GetItem(262, 1), itemDb.GetItem(261, 30),
                                                                        itemDb.GetItem(263, 30), itemDb.GetItem(264, 30),
                                                                        itemDb.GetItem(265, 30), itemDb.GetItem(266, 30),
                                                                        itemDb.GetItem(124, 30)})),
                new Shop(4, "Livestock Shop", new ShopContainer(new Item[] { itemDb.GetItem(272, 50), itemDb.GetItem(273, 10),
                                                                        itemDb.GetItem(274, 1) })),
                new Shop(5, "Archery Ammo Shop", new ShopContainer(new Item[] { itemDb.GetItem(116, 100) , itemDb.GetItem(117,100),
                                                                        itemDb.GetItem(118, 100) , itemDb.GetItem(119,100),
                                                                        itemDb.GetItem(120, 100) , itemDb.GetItem(121,100),
                                                                        itemDb.GetItem(122, 100) , itemDb.GetItem(123,100),
                                                                        itemDb.GetItem(125, 100) , itemDb.GetItem(126,100),
                                                                        itemDb.GetItem(127, 100) , itemDb.GetItem(128,100),
                                                                        itemDb.GetItem(129, 100) , itemDb.GetItem(130,100),
                                                                        itemDb.GetItem(131, 100) , itemDb.GetItem(132,100)})),
                new Shop(6, "Archery Armor Shop", new ShopContainer(new Item[] {itemDb.GetItem(133, 1) , itemDb.GetItem(134,1),
                                                                        itemDb.GetItem(135, 1) , itemDb.GetItem(136,1),
                                                                        itemDb.GetItem(137, 1) , itemDb.GetItem(138,1),
                                                                        itemDb.GetItem(139, 1) , itemDb.GetItem(140,1),
                                                                        itemDb.GetItem(141, 1) , itemDb.GetItem(142,1),
                                                                        itemDb.GetItem(143, 1) , itemDb.GetItem(144,1),
                                                                        itemDb.GetItem(145, 1) , itemDb.GetItem(146,1),
                                                                        itemDb.GetItem(147, 1) , itemDb.GetItem(148,1),
                                                                        itemDb.GetItem(149, 1) , itemDb.GetItem(150,1),
                                                                        itemDb.GetItem(151, 1) , itemDb.GetItem(152,1),
                                                                        itemDb.GetItem(153, 1) , itemDb.GetItem(154,1),
                                                                        itemDb.GetItem(155, 1) , itemDb.GetItem(156,1),
                                                                        itemDb.GetItem(157, 1) , itemDb.GetItem(158,1),
                                                                        itemDb.GetItem(159, 1) , itemDb.GetItem(160,1),
                                                                        itemDb.GetItem(161, 1) , itemDb.GetItem(162,1),
                                                                        itemDb.GetItem(163, 1) , itemDb.GetItem(164,1),
                                                                        itemDb.GetItem(165, 1) , itemDb.GetItem(166,1),
                                                                        itemDb.GetItem(167, 1) , itemDb.GetItem(168,1),
                                                                        itemDb.GetItem(169, 1) , itemDb.GetItem(170,1),
                                                                        itemDb.GetItem(171, 1) , itemDb.GetItem(172,1)})),
                new Shop(7, "Archery Weaponry Shop", new ShopContainer(new Item[] { itemDb.GetItem(12, 1), itemDb.GetItem(13, 1),
                                                                        itemDb.GetItem(14, 1) , itemDb.GetItem(15,1),
                                                                        itemDb.GetItem(16, 1) , itemDb.GetItem(17,1),
                                                                        itemDb.GetItem(18, 1) , itemDb.GetItem(19,1),
                                                                        itemDb.GetItem(76, 1) , itemDb.GetItem(77,1),
                                                                        itemDb.GetItem(78, 1) , itemDb.GetItem(79,1),
                                                                        itemDb.GetItem(80, 1) , itemDb.GetItem(81,1),
                                                                        itemDb.GetItem(82, 1) , itemDb.GetItem(83,1),
                                                                        itemDb.GetItem(84, 1) , itemDb.GetItem(85,1),
                                                                        itemDb.GetItem(86, 1) , itemDb.GetItem(87,1),
                                                                        itemDb.GetItem(88, 1) , itemDb.GetItem(89,1),
                                                                        itemDb.GetItem(90, 1) , itemDb.GetItem(91,1),
                                                                        itemDb.GetItem(92, 1) , itemDb.GetItem(93,1),
                                                                        itemDb.GetItem(94, 1) , itemDb.GetItem(95,1),
                                                                        itemDb.GetItem(96, 1) , itemDb.GetItem(97,1),
                                                                        itemDb.GetItem(98, 1) , itemDb.GetItem(99,1),
                                                                        itemDb.GetItem(100, 1) , itemDb.GetItem(101,1),
                                                                        itemDb.GetItem(102, 1) , itemDb.GetItem(103,1),
                                                                        itemDb.GetItem(104, 1) , itemDb.GetItem(105,1),
                                                                        itemDb.GetItem(106, 1) , itemDb.GetItem(107,1),
                                                                        itemDb.GetItem(108, 100) , itemDb.GetItem(109,100),
                                                                        itemDb.GetItem(110, 100) , itemDb.GetItem(111,100),
                                                                        itemDb.GetItem(112, 100) , itemDb.GetItem(113,100),
                                                                        itemDb.GetItem(114, 100) , itemDb.GetItem(115,100)})),
                new Shop(8, "Warrior Ammo Shop", new ShopContainer(new Item[] { itemDb.GetItem(75,100)})),
                new Shop(9, "Warrior Armor Shop", new ShopContainer(new Item[] { itemDb.GetItem(44, 1), itemDb.GetItem(45, 1),
                                                                        itemDb.GetItem(46, 1) , itemDb.GetItem(47,1),
                                                                        itemDb.GetItem(48, 1) , itemDb.GetItem(49,1),
                                                                        itemDb.GetItem(50, 1) , itemDb.GetItem(51,1),
                                                                        itemDb.GetItem(52, 1), itemDb.GetItem(53, 1),
                                                                        itemDb.GetItem(54, 1) , itemDb.GetItem(55,1),
                                                                        itemDb.GetItem(56, 1) , itemDb.GetItem(57,1),
                                                                        itemDb.GetItem(58, 1) , itemDb.GetItem(59,1),
                                                                        itemDb.GetItem(60, 1), itemDb.GetItem(61, 1),
                                                                        itemDb.GetItem(62, 1) , itemDb.GetItem(63,1),
                                                                        itemDb.GetItem(64, 1) , itemDb.GetItem(65,1),
                                                                        itemDb.GetItem(66, 1) , itemDb.GetItem(67,1),
                                                                        itemDb.GetItem(68, 1), itemDb.GetItem(69, 1),
                                                                        itemDb.GetItem(70, 1) , itemDb.GetItem(71,1),
                                                                        itemDb.GetItem(72, 1) , itemDb.GetItem(73,1),
                                                                        itemDb.GetItem(74, 1)})),
                new Shop(10, "Warrior Weaponry Shop", new ShopContainer(new Item[] {itemDb.GetItem(4, 1) , itemDb.GetItem(5,1),
                                                                        itemDb.GetItem(6, 1) , itemDb.GetItem(7,1),
                                                                        itemDb.GetItem(8, 1) , itemDb.GetItem(9,1),
                                                                        itemDb.GetItem(10, 1) , itemDb.GetItem(11,1),
                                                                        itemDb.GetItem(12, 1), itemDb.GetItem(13, 1),
                                                                        itemDb.GetItem(14, 1) , itemDb.GetItem(15,1),
                                                                        itemDb.GetItem(16, 1) , itemDb.GetItem(17,1),
                                                                        itemDb.GetItem(18, 1) , itemDb.GetItem(19,1),
                                                                        itemDb.GetItem(20, 1), itemDb.GetItem(21, 1),
                                                                        itemDb.GetItem(22, 1) , itemDb.GetItem(23,1),
                                                                        itemDb.GetItem(24, 1) , itemDb.GetItem(25,1),
                                                                        itemDb.GetItem(26, 1) , itemDb.GetItem(27,1),
                                                                        itemDb.GetItem(28, 1), itemDb.GetItem(29, 1),
                                                                        itemDb.GetItem(30, 1) , itemDb.GetItem(31,1),
                                                                        itemDb.GetItem(32, 1) , itemDb.GetItem(33,1),
                                                                        itemDb.GetItem(34, 1) , itemDb.GetItem(35,1),
                                                                        itemDb.GetItem(36, 1), itemDb.GetItem(37, 1),
                                                                        itemDb.GetItem(38, 1) , itemDb.GetItem(39,1),
                                                                        itemDb.GetItem(40, 1) , itemDb.GetItem(41,1),
                                                                        itemDb.GetItem(42, 1) , itemDb.GetItem(43,1)})),
            };
        }

        public Shop GetShop(int id)
        {
            return items.Where(i => i.Id == id).FirstOrDefault() as Shop;
        }
    }
}
