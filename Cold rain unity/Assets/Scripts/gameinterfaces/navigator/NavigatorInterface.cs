﻿using Assets.Scripts.gameinterfaces.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.navigator
{
    public class NavigatorInterface : GameInterface
    {
        public Button InventoryButton;
        public Button EquipButton;
        public Button SkillsButton;
        public Button QuestButton;
        public Button OptionsButton;
        public Button MapButton;

        public Inventory InventoryInterface;
        public SkillsInterface SkillsInterface;
        public EquipmentInterface EquipmentInterface;
        public GameObject MapInterface;
        public ReportBugInterface BugReportInterface;

        public GameObject canvas;
        
        public void ToggleInventoryActivity() =>
            InventoryInterface.ToggleActive();

        public void ToggleEquipActivity() =>
            EquipmentInterface.ToggleActive();

        public void ToggleSkillsActivity() =>
            SkillsInterface.ToggleActive();

        public void ToggleMapActivity() =>
            MapInterface.SetActive(!MapInterface.activeSelf);

        public void ToggleReportActivity() =>
            BugReportInterface.ToggleActive();

        public override void Create(Player player)
        {
            this.player = player;
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
