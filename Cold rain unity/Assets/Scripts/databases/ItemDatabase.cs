using Assets.Scripts.item;
using Assets.Scripts.logger;
using Assets.Scripts.node;
using Assets.Scripts.stats;
using Assets.Scripts.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.databases
{
    /// <summary>
    /// Items stored in this game
    /// </summary>
    public class ItemDatabase : CRDatabase
    {
        /// <summary>
        /// The inventory icons
        /// </summary>
        private Sprite[] InventoryIcon;
        
        /// <summary>
        /// Builds the item database
        /// </summary>
        public override void BuildDatabase()
        {
            CrLogger.Log(this, "Building item database...");

            items = new List<DbElement>()
            {
                new Item(0, "Hedgehog plushie", false, new Stats(), new Skills(), "A nice plushie, it says POG on the label.", false, true),
                new Item(1, "Rat plushie", false, new Stats(), new Skills(), "When you squeeze it, it squeeks!", false, true),
                new Item(2, "Cat plushie", false, new Stats(), new Skills(), "Meeeeeeeow", false, true),
                new Item(3, "Dog plushie", false, new Stats(), new Skills(), "He doesn't do much but he's a good boy.", false, true),
                new Item(4, "Wood sword", false, new Stats(), new Skills(), "a regular sword made out of wood.", false, true),
                new Item(5, "Bronze sword", false, new Stats(), new Skills(), "a regular sword made out of bronze.", false, true),
                new Item(6, "Silver sword", false, new Stats(), new Skills(), "a regular sword made out of silver.", false, true),
                new Item(7, "Gold sword", false, new Stats(), new Skills(), "a regular sword made out of gold.", false, true),
                new Item(8, "Platinum sword", false, new Stats(), new Skills(), "a regular sword made out of platinum.", false, true),
                new Item(9, "Ruby sword", false, new Stats(), new Skills(), "a sword made out of platinum. There's a ruby in the rain-guard.", false, true),
                new Item(10, "Emerald sword", false, new Stats(), new Skills(), "a sword made out of platinum. There's an emerald in the rain-guard.", false, true),
                new Item(11, "Sapphire sword", false, new Stats(), new Skills(), "a sword made out of platinum. There's a sapphire in the rain-guard.", false, true),
                new Item(12, "Wood shield", false, new Stats(), new Skills(), "a regular shield made out of wood.", false, true),
                new Item(13, "Bronze shield", false, new Stats(), new Skills(), "a regular shield made out of bronze.", false, true),
                new Item(14, "Silver shield", false, new Stats(), new Skills(), "a regular shield made out of silver.", false, true),
                new Item(15, "Gold shield", false, new Stats(), new Skills(), "a regular shield made out of gold.", false, true),
                new Item(16, "Platinum shield", false, new Stats(), new Skills(), "a regular shield made out of platinum.", false, true),
                new Item(17, "Ruby shield", false, new Stats(), new Skills(), "a shield made out of platinum. There's a ruby at the center of the disc.", false, true),
                new Item(18, "Emerald shield", false, new Stats(), new Skills(), "a shield made out of platinum. There's an emerald at the center of the disc.", false, true),
                new Item(19, "Sapphire shield", false, new Stats(), new Skills(), "a shield made out of platinum. There's a sapphire at the center of the disc.", false, true),
                new Item(20, "Wood dagger", false, new Stats(), new Skills(), "a regular dagger made out of wood.", false, true),
                new Item(21, "Bronze dagger", false, new Stats(), new Skills(), "a regular dagger made out of bronze.", false, true),
                new Item(22, "Silver dagger", false, new Stats(), new Skills(), "a regular dagger made out of silver.", false, true),
                new Item(23, "Gold dagger", false, new Stats(), new Skills(), "a regular dagger made out of gold.", false, true),
                new Item(24, "Platinum dagger", false, new Stats(), new Skills(), "a regular dagger made out of platinum.", false, true),
                new Item(25, "Ruby dagger", false, new Stats(), new Skills(), "a dagger made out of platinum. There's a ruby in the rain-guard.", false, true),
                new Item(26, "Emerald dagger", false, new Stats(), new Skills(), "a dagger made out of platinum. There's an emerald in the rain-guard.", false, true),
                new Item(27, "Sapphire dagger", false, new Stats(), new Skills(), "a dagger made out of platinum. There's a sapphire in the rain-guard.", false, true),
                new Item(28, "Wood greataxe", false, new Stats(), new Skills(), "a regular greataxe made out of wood.", false, true),
                new Item(29, "Bronze greataxe", false, new Stats(), new Skills(), "a regular greataxe made out of bronze.", false, true),
                new Item(30, "Silver greataxe", false, new Stats(), new Skills(), "a regular greataxe made out of silver.", false, true),
                new Item(31, "Gold greataxe", false, new Stats(), new Skills(), "a regular greataxe made out of gold.", false, true),
                new Item(32, "Platinum greataxe", false, new Stats(), new Skills(), "a regular greataxe made out of platinum.", false, true),
                new Item(33, "Ruby greataxe", false, new Stats(), new Skills(), "a greataxe made out of platinum. There's a ruby inbetween the blades.", false, true),
                new Item(34, "Emerald greataxe", false, new Stats(), new Skills(), "a greataxe made out of platinum. There's an emerald inbetween the blades.", false, true),
                new Item(35, "Sapphire greataxe", false, new Stats(), new Skills(), "a greataxe made out of platinum. There's a sapphire inbetween the blades.", false, true),
                new Item(36, "Wood scythe", false, new Stats(), new Skills(), "a regular scythe made out of wood.", false, true),
                new Item(37, "Bronze scythe", false, new Stats(), new Skills(), "a regular scythe made out of bronze.", false, true),
                new Item(38, "Silver scythe", false, new Stats(), new Skills(), "a regular scythe made out of silver.", false, true),
                new Item(39, "Gold scythe", false, new Stats(), new Skills(), "a regular scythe made out of gold.", false, true),
                new Item(40, "Platinum scythe", false, new Stats(), new Skills(), "a regular scythe made out of platinum.", false, true),
                new Item(41, "Ruby scythe", false, new Stats(), new Skills(), "a scythe made out of platinum. The attachment ring is decorated with a ruby.", false, true),
                new Item(42, "Emerald scythe", false, new Stats(), new Skills(), "a scythe made out of platinum. The attachment ring is decorated with an emerald", false, true),
                new Item(43, "Sapphire scythe", false, new Stats(), new Skills(), "a scythe made out of platinum. The attachment ring is decorated with a sapphire", false, true),
                new Item(44, "Bronze helmet", false, new Stats(), new Skills(), "a regular helmet made out of bronze.", false, true),
                new Item(45, "Silver helmet", false, new Stats(), new Skills(), "a regular helmet made out of silver.", false, true),
                new Item(46, "Gold helmet", false, new Stats(), new Skills(), "a regular helmet made out of gold.", false, true),
                new Item(47, "Platinum helmet", false, new Stats(), new Skills(), "a regular helmet made out of platinum.", false, true),
                new Item(48, "Ruby helmet", false, new Stats(), new Skills(), "a helmet made out of platinum. It is decorated with a ruby.", false, true),
                new Item(49, "Emerald helmet", false, new Stats(), new Skills(), "a helmet made out of platinum. It is decorated with an emerald.", false, true),
                new Item(50, "Sapphire helmet", false, new Stats(), new Skills(), "a helmet made out of platinum. It is decorated with a sapphire", false, true),
                new Item(51, "Bronze chestplate", false, new Stats(), new Skills(), "a regular chestplate made out of bronze.", false, true),
                new Item(52, "Silver chestplate", false, new Stats(), new Skills(), "a regular chestplate made out of silver.", false, true),
                new Item(53, "Gold chestplate", false, new Stats(), new Skills(), "a regular chestplate made out of gold.", false, true),
                new Item(54, "Platinum chestplate", false, new Stats(), new Skills(), "a regular chestplate made out of platinum.", false, true),
                new Item(55, "Ruby chestplate", false, new Stats(), new Skills(), "a chestplate made out of platinum. It is decorated with a ruby.", false, true),
                new Item(56, "Emerald chestplate", false, new Stats(), new Skills(), "a chestplate made out of platinum. It is decorated with an emerald", false, true),
                new Item(57, "Sapphire chestplate", false, new Stats(), new Skills(), "a chestplate made out of platinum. It is decorated with a sapphire", false, true),
                new Item(58, "Bronze legs", false, new Stats(), new Skills(), "a regular pair of legs, made out of bronze.", false, true),
                new Item(59, "Silver legs", false, new Stats(), new Skills(), "a regular pair of legs, made out of silver.", false, true),
                new Item(60, "Gold legs", false, new Stats(), new Skills(), "a regular pair of legs, made out of gold.", false, true),
                new Item(61, "Platinum legs", false, new Stats(), new Skills(), "a regular pair of legs, made out of platinum.", false, true),
                new Item(62, "Ruby legs", false, new Stats(), new Skills(), "a pair of legs made out of platinum. They're decorated with a ruby.", false, true),
                new Item(63, "Emerald legs", false, new Stats(), new Skills(), "a pair of legs made out of platinum. They're decorated with an emerald", false, true),
                new Item(64, "Sapphire legs", false, new Stats(), new Skills(), "a pair of legs made out of platinum. They're decoared with a sapphire", false, true),
                new Item(65, "Bronze boots", false, new Stats(), new Skills(), "a regular pair of boots made out of bronze.", false, true),
                new Item(66, "Silver boots", false, new Stats(), new Skills(), "a regular pair of boots made out of silver.", false, true),
                new Item(67, "Gold boots", false, new Stats(), new Skills(), "a regular pair of boots made out of gold.", false, true),
                new Item(68, "Platinum boots", false, new Stats(), new Skills(), "a regular pair of boots made out of platinum.", false, true),
                new Item(69, "Ruby boots", false, new Stats(), new Skills(), "a pair of boots made out of platinum. The nose is decorated with a ruby.", false, true),
                new Item(70, "Emerald boots", false, new Stats(), new Skills(), "a boots made out of platinum. The nose is decorated with an emerald", false, true),
                new Item(71, "Sapphire boots", false, new Stats(), new Skills(), "a boots made out of platinum. The nose is decorated with a sapphire", false, true),
                new Item(72, "Ruby amulet", false, new Stats(), new Skills(), "an amulet made of gold, with a beatiful ruby on it.", false, true),
                new Item(73, "Emerald amulet", false, new Stats(), new Skills(), "an amulet made of gold, with a beatiful emerald on it", false, true),
                new Item(74, "Sapphire amulet", false, new Stats(), new Skills(), "a an amulet made of gold, with a beatiful sapphire on it", false, true),
                new Item(75, "Rock", true, new Stats(), new Skills(), "a light rock that can easily gain attention from someone by being thrown at them.", false, true),
                new Item(76, "Wood bow", false, new Stats(), new Skills(), "a regular bow made out of Wood.", false, true),
                new Item(77, "Bronze bow", false, new Stats(), new Skills(), "a regular bow made out of bronze.", false, true),
                new Item(78, "Silver bow", false, new Stats(), new Skills(), "a regular bow made out of silver.", false, true),
                new Item(79, "Gold bow", false, new Stats(), new Skills(), "a regular bow made out of gold.", false, true),
                new Item(80, "Platinum bow", false, new Stats(), new Skills(), "a regular bow made out of platinum.", false, true),
                new Item(81, "Ruby bow", false, new Stats(), new Skills(), "a bow made out of platinum. It's decorated with a ruby close to the arrow rest.", false, true),
                new Item(82, "Emerald bow", false, new Stats(), new Skills(), "a bow made out of platinum. It's decorated with an emerald close to the arrow rest.", false, true),
                new Item(83, "Sapphire bow", false, new Stats(), new Skills(), "a bow made out of platinum. It's decorated with a sapphire close to the arrow rest.", false, true),
                new Item(84, "Wood crossbow", false, new Stats(), new Skills(), "a regular crossbow made out of Wood.", false, true),
                new Item(85, "Bronze crossbow", false, new Stats(), new Skills(), "a regular crossbow made out of bronze.", false, true),
                new Item(86, "Silver crossbow", false, new Stats(), new Skills(), "a regular crossbow made out of silver.", false, true),
                new Item(87, "Gold crossbow", false, new Stats(), new Skills(), "a regular crossbow made out of gold.", false, true),
                new Item(88, "Platinum crossbow", false, new Stats(), new Skills(), "a regular crossbow made out of platinum.", false, true),
                new Item(89, "Ruby crossbow", false, new Stats(), new Skills(), "a crossbow made out of platinum. It's stock is decorated with a ruby.", false, true),
                new Item(90, "Emerald crossbow", false, new Stats(), new Skills(), "a crossbow made out of platinum. It's stock is decorated with an emerald.", false, true),
                new Item(91, "Sapphire crossbow", false, new Stats(), new Skills(), "a crossbow made out of platinum. It's stock is decorated with a sapphire.", false, true),
                new Item(92, "Wood shortbow", false, new Stats(), new Skills(), "a regular shortbow made out of Wood.", false, true),
                new Item(93, "Bronze shortbow", false, new Stats(), new Skills(), "a regular shortbow made out of bronze.", false, true),
                new Item(94, "Silver shortbow", false, new Stats(), new Skills(), "a regular shortbow made out of silver.", false, true),
                new Item(95, "Gold shortbow", false, new Stats(), new Skills(), "a regular shortbow made out of gold.", false, true),
                new Item(96, "Platinum shortbow", false, new Stats(), new Skills(), "a regular shortbow made out of platinum.", false, true),
                new Item(97, "Ruby shortbow", false, new Stats(), new Skills(), "a shortbow made out of platinum. It's decorated with a ruby close to the arrow rest.", false, true),
                new Item(98, "Emerald shortbow", false, new Stats(), new Skills(), "a shortbow made out of platinum. It's decorated with an emerald close to the arrow rest.", false, true),
                new Item(99, "Sapphire shortbow", false, new Stats(), new Skills(), "a shortbow made out of platinum. It's decorated with a sapphire close to the arrow rest.", false, true),
                new Item(100, "Wood longbow", false, new Stats(), new Skills(), "a regular longbow made out of Wood.", false, true),
                new Item(101, "Bronze longbow", false, new Stats(), new Skills(), "a regular longbow made out of bronze.", false, true),
                new Item(102, "Silver longbow", false, new Stats(), new Skills(), "a regular longbow made out of silver.", false, true),
                new Item(103, "Gold longbow", false, new Stats(), new Skills(), "a regular longbow made out of gold.", false, true),
                new Item(104, "Platinum longbow", false, new Stats(), new Skills(), "a regular longbow made out of platinum.", false, true),
                new Item(105, "Ruby longbow", false, new Stats(), new Skills(), "a longbow made out of platinum. It's decorated with a ruby close to the arrow rest.", false, true),
                new Item(106, "Emerald longbow", false, new Stats(), new Skills(), "a longbow made out of platinum. It's decorated with an emerald close to the arrow rest.", false, true),
                new Item(107, "Sapphire longbow", false, new Stats(), new Skills(), "a longbow made out of platinum. It's decorated with a sapphire close to the arrow rest.", false, true),
                new Item(108, "Wood chakram", true, new Stats(), new Skills(), "a regular chakram made out of Wood.", false, true),
                new Item(109, "Bronze chakram", true, new Stats(), new Skills(), "a regular chakram made out of bronze.", false, true),
                new Item(110, "Silver chakram", true, new Stats(), new Skills(), "a regular chakram made out of silver.", false, true),
                new Item(111, "Gold chakram", true, new Stats(), new Skills(), "a regular chakram made out of gold.", false, true),
                new Item(112, "Platinum chakram", true, new Stats(), new Skills(), "a regular chakram made out of platinum.", false, true),
                new Item(113, "Ruby chakram", true, new Stats(), new Skills(), "a chakram made out of platinum. It's handle is decorated with a ruby.", false, true),
                new Item(114, "Emerald chakram", true, new Stats(), new Skills(), "a chakram made out of platinum. It's handle is decorated with an emerald.", false, true),
                new Item(115, "Sapphire chakram", true, new Stats(), new Skills(), "a chakram made out of platinum. It's handle is decorated with a sapphire.", false, true),
                new Item(116, "Wood arrow", true, new Stats(), new Skills(), "a regular arrow made out of Wood.", false, true),
                new Item(117, "Bronze arrow", true, new Stats(), new Skills(), "a regular arrow, with a bronze tip.", false, true),
                new Item(118, "Silver arrow", true, new Stats(), new Skills(), "a regular arrow, with a silver tip.", false, true),
                new Item(119, "Gold arrow", true, new Stats(), new Skills(), "a regular arrow, with a gold tip.", false, true),
                new Item(120, "Platinum arrow", true, new Stats(), new Skills(), "a regular arrow, with a platinum tip.", false, true),
                new Item(121, "Ruby arrow", true, new Stats(), new Skills(), "an arrow made out of platinum. Its tip is made out of ruby.", false, true),
                new Item(122, "Emerald arrow", true, new Stats(), new Skills(), "an arrow made out of platinum. Its tip is made out of emerald.", false, true),
                new Item(123, "Sapphire arrow", true, new Stats(), new Skills(), "an arrow made out of platinum. Its tip is made out of sapphire.", false, true),
                new Item(125, "Wood bolt", true, new Stats(), new Skills(), "a regular bolt made out of Wood.", false, true),
                new Item(126, "Bronze bolt", true, new Stats(), new Skills(), "a regular bolt made out of bronze.", false, true),
                new Item(127, "Silver bolt", true, new Stats(), new Skills(), "a regular bolt made out of silver.", false, true),
                new Item(128, "Gold bolt", true, new Stats(), new Skills(), "a regular bolt made out of gold.", false, true),
                new Item(129, "Platinum bolt", true, new Stats(), new Skills(), "a regular bolt made out of platinum.", false, true),
                new Item(130, "Ruby bolt", true, new Stats(), new Skills(), "a bolt made out of platinum. Its tip is made out of ruby.", false, true),
                new Item(131, "Emerald bolt", true, new Stats(), new Skills(), "a bolt made out of platinum. Its tip is made out of emerald.", false, true),
                new Item(132, "Sapphire bolt", true, new Stats(), new Skills(), "a bolt made out of platinum. Its tip is made out of sapphire.", false, true),
                new Item(133, "Green leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a green deer.", false, true),
                new Item(134, "Turquoise leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a turquoise deer.", false, true),
                new Item(135, "Blue leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a blue deer.", false, true),
                new Item(136, "Purple leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a purple deer.", false, true),
                new Item(137, "Red leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a red deer.", false, true),
                new Item(138, "Black leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a black deer.", false, true),
                new Item(139, "White leather helmet", false, new Stats(), new Skills(), "a helmet made with the leather from a white deer.", false, true),
                new Item(140, "White leather helmet(r)", false, new Stats(), new Skills(), "a helmet made with the leather from a white deer. It's decorated with a big ruby.", false, true),
                new Item(141, "White leather helmet(e)", false, new Stats(), new Skills(), "a helmet made with the leather from a white deer. It's decorated with a big emerald", false, true),
                new Item(142, "White leather helmet(s)", false, new Stats(), new Skills(), "a helmet made with the leather from a white deer. It's decorated with a big sapphire", false, true),
                new Item(143, "Green leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a green deer.", false, true),
                new Item(144, "Turquoise leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a turquoise deer.", false, true),
                new Item(145, "Blue leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a blue deer.", false, true),
                new Item(146, "Purple leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a purple deer.", false, true),
                new Item(147, "Red leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a red deer.", false, true),
                new Item(148, "Black leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a black deer.", false, true),
                new Item(149, "White leather chestplate", false, new Stats(), new Skills(), "a chestplate made with the leather from a white deer.", false, true),
                new Item(150, "White leather chestplate(r)", false, new Stats(), new Skills(), "a chestplate made with the leather from a white deer. It's decorated with a big ruby.", false, true),
                new Item(151, "White leather chestplate(e)", false, new Stats(), new Skills(), "a chestplate made with the leather from a white deer. It's decorated with a big emerald", false, true),
                new Item(152, "White leather chestplate(s)", false, new Stats(), new Skills(), "a chestplate made with the leather from a white deer. It's decorated with a big sapphire", false, true),
                new Item(153, "Green leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a green deer.", false, true),
                new Item(154, "Turquoise leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a turquoise deer.", false, true),
                new Item(155, "Blue leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a blue deer.", false, true),
                new Item(156, "Purple leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a purple deer.", false, true),
                new Item(157, "Red leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a red deer.", false, true),
                new Item(158, "Black leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a black deer.", false, true),
                new Item(159, "White leather legs", false, new Stats(), new Skills(), "a pair of legs made with the leather from a white deer.", false, true),
                new Item(160, "White leather legs(r)", false, new Stats(), new Skills(), "a pair of legs made with the leather from a white deer. It's decorated with a ruby.", false, true),
                new Item(161, "White leather legs(e)", false, new Stats(), new Skills(), "a pair of legs made with the leather from a white deer. It's decorated with an emerald", false, true),
                new Item(162, "White leather legs(s)", false, new Stats(), new Skills(), "a pair of legs made with the leather from a white deer. It's decorated with a sapphire", false, true),
                new Item(163, "Green leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a green deer.", false, true),
                new Item(164, "Turquoise leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a turquoise deer.", false, true),
                new Item(165, "Blue leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a blue deer.", false, true),
                new Item(166, "Purple leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a purple deer.", false, true),
                new Item(167, "Red leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a red deer.", false, true),
                new Item(168, "Black leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a black deer.", false, true),
                new Item(169, "White leather boots", false, new Stats(), new Skills(), "a pair of boots made with the leather from a white deer.", false, true),
                new Item(170, "White leather boots(r)", false, new Stats(), new Skills(), "a pair of boots made with the leather from a white deer. It's decorated with a ruby.", false, true),
                new Item(171, "White leather boots(e)", false, new Stats(), new Skills(), "a pair of boots made with the leather from a white deer. It's decorated with an emerald", false, true),
                new Item(172, "White leather boots(s)", false, new Stats(), new Skills(), "a pair of boots made with the leather from a white deer. It's decorated with a sapphire", false, true),
                new Item(173, "Rodent trap", true, new Stats(), new Skills(), "Useful for catching rodents.", false, true),
                new Item(174, "Bird trap", true, new Stats(), new Skills(), "Conveniently made with two spoons.", false, true),
                new Item(175, "Deer bait", true, new Stats(), new Skills(), "The smell lures deer.", false, true),
                new Item(176, "Game call", false, new Stats(), new Skills(), "an odd sounding instrument that mimics the sound of deer.", false, true),
                new Item(177, "Green deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead green deers body. you monster.", false, true),
                new Item(178, "Turquoise deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead turquoise deers body. you monster.", false, true),
                new Item(179, "Blue deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead blue deers body. you monster.", false, true),
                new Item(180, "Purple deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead purple deers body. you monster.", false, true),
                new Item(181, "Red deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead red deers body. you monster.", false, true),
                new Item(182, "Black deer leather", true, new Stats(), new Skills(), "Leather that you took from a dead black deers body. you monster.", false, true),
                new Item(183, "White deer leather", true, new Stats(), new Skills(), "Leather from a magnificent white deer. I hope you realize you might have killed the last of it's species.", false, true),
                new Item(184, "Green deer meat", true, new Stats(), new Skills(), "Yuck, only poor folks eat green deer meat.", false, true),
                new Item(185, "Turquoise deer meat", true, new Stats(), new Skills(), "The commoners favorite meat.", false, true),
                new Item(186, "Blue deer meat", true, new Stats(), new Skills(), "Tastes the same as pig, and they've spent their lives rolling around in the mud.", false, true),
                new Item(187, "Purple deer meat", true, new Stats(), new Skills(), "Deer meat with a wealthy taste.", false, true),
                new Item(188, "Red deer meat", true, new Stats(), new Skills(), "Doctors say eating red meat is bad for you.. but it tastes good so who cares.", false, true),
                new Item(189, "Black deer meat", true, new Stats(), new Skills(), "Finally some good fucking food.", false, true),
                new Item(190, "White deer meat", true, new Stats(), new Skills(), "Now this is some real gourmet shit.", false, true),
                new Item(191, "Raw green deer meat", true, new Stats(), new Skills(), "Yuck, only poor folks eat green deer meat.", false, true),
                new Item(192, "Raw Turquoise deer meat", true, new Stats(), new Skills(), "The commoners favorite meat.", false, true),
                new Item(193, "Raw blue deer meat", true, new Stats(), new Skills(), "Tastes the same as pig, and they've spent their lives rolling around in the mud.", false, true),
                new Item(194, "Raw purple deer meat", true, new Stats(), new Skills(), "Deer meat with a wealthy taste.", false, true),
                new Item(195, "Raw red deer meat", true, new Stats(), new Skills(), "Doctors say eating red meat is bad for you.. but it tastes good so who cares.", false, true),
                new Item(196, "Raw black deer meat", true, new Stats(), new Skills(), "Finally some good fucking food.", false, true),
                new Item(197, "Raw white deer meat", true, new Stats(), new Skills(), "Now this is some real gourmet shit.", false, true),
                new Item(198, "Mallard duck breast", true, new Stats(), new Skills(), "No more quacking for this duck.", false, true),
                new Item(199, "Tufted duck breast", true, new Stats(), new Skills(), "This duck waddled right into its own grave.", false, true),
                new Item(200, "Raw mallard duck breast", true, new Stats(), new Skills(), "No more quacking for this duck.", false, true),
                new Item(201, "Raw tufted duck breast", true, new Stats(), new Skills(), "This duck waddled right into its own grave.", false, true),
                new Item(202, "Canada goose breast", true, new Stats(), new Skills(), "I'm glad the big pest is dead.", false, true),
                new Item(203, "Greylag goose breast", true, new Stats(), new Skills(), "An average breast from an average goose.", false, true),
                new Item(204, "Pinkfoot goose breast", true, new Stats(), new Skills(), "Not sure if this was a goose or a duck.", false, true),
                new Item(205, "Raw Canada goose breast", true, new Stats(), new Skills(), "I'm glad the big pest is dead.", false, true),
                new Item(206, "Raw Greylag goose breast", true, new Stats(), new Skills(), "An average breast from an average goose.", false, true),
                new Item(207, "Raw Pinkfoot goose breast", true, new Stats(), new Skills(), "Not sure if this was a goose or a duck.", false, true),
                new Item(208, "Featers", true, new Stats(), new Skills(), "Plucked from the dead body of some bird.", false, true),
                new Item(209, "Rabbit", true, new Stats(), new Skills(), "Small, cute, and begging to be eaten.", false, true),
                new Item(210, "Hare", true, new Stats(), new Skills(), "Big, fast, and very nutritious.", false, true),
                new Item(211, "Raw rabbit", true, new Stats(), new Skills(), "Small, cute, and begging to be cooked.", false, true),
                new Item(212, "Raw hare", true, new Stats(), new Skills(), "Big, fast, and soon to be very nutritious.", false, true),
                new Item(213, "Lucky rabbit's foot", true, new Stats(), new Skills(), "The foot of a rabbit, it's said to bring luck when worn as an amulet.", false, true),
                new Item(214, "Lucky rabbit's amulet", true, new Stats(), new Skills(), "An amulet with the foot of a rabbit. Don't let the animal protection see this.", false, true),
                new Item(215, "Pheasant breast", true, new Stats(), new Skills(), "It used to be a beatiful bird, and now it's a beatiful meal.", false, true),
                new Item(216, "Woodpidgeon breast", true, new Stats(), new Skills(), "The vermin of the sky, good riddance.", false, true),
                new Item(217, "Corncrake breast", true, new Stats(), new Skills(), "A cute bird with a small brain.", false, true),
                new Item(218, "Raw pheasant breast", true, new Stats(), new Skills(), "It used to be a beatiful bird, and now it's a beatiful corpse.", false, true),
                new Item(219, "Raw woodpidgeon breast", true, new Stats(), new Skills(), "The vermin of the sky, good riddance.", false, true),
                new Item(220, "Raw corncrake breast", true, new Stats(), new Skills(), "A cute bird with a small brain.", false, true),
            };

            EquipmentArray = new EquipmentItemMultiArray[items.Count];
            InventoryIcon = new Sprite[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                EquipmentArray[i] = new EquipmentItemMultiArray();
                EquipmentArray[i].EquipSprites = new Sprite[4];
                for (int j = 0; j < EquipmentArray[i].EquipSprites.Length; j++)
                {
                    InventoryIcon[i] = Resources.Load<Sprite>($"Item/{i}/item_{i}");
                    EquipmentArray[i].EquipSprites[j] = Resources.Load<Sprite>($"Item/{i}/item_{i}_{j}");
                }
            }

            //for(int i = 0; i < InventoryIcon.Length; i++)
            //    ((Item)items[i]).SetSprites(InventoryIcon[i], EquipmentArray[i]);



            CrLogger.Log(this, "The item database was built succesfully");
        }

        public Item GetItem(int id)
        {
            Item it;
            it = items.Where(i => i.Id == id).FirstOrDefault() as Item;
            return it;
        }
    }
}
