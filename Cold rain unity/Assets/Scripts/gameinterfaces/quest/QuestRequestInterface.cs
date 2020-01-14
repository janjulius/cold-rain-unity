using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.quest
{
    public class QuestRequestInterface : GameInterface
    {
        public TextMeshProUGUI title, description, rewards;
        public Button acceptButton, declineButton;

        private Quest quest;

        public void Load(Quest quest, Player player)
        {
            this.quest = quest;
            this.player = this.player ?? player;
            GameConsole.Instance.SendDevMessage($"Loaded questreq interface: {quest.ToString()}");
            Refresh();
        }

        public override void Create(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            title.text = quest.Name;
            description.text = quest.Description;
            rewards.text = quest.Rewards;
        }

        public void AcceptQuest()
        {
            quest.Accept();
            SetActive(false);
        }

        public void DeclineQuest()
        {
            SetActive(false);
        }
    }
}
