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
        
        public override void Create(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
