using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets.Scripts.gameinterfaces.activity
{
    public class ActivityInterface : GameInterface
    {
        public TextMeshProUGUI mainText;

        public override void Create(Player player)
        {
            this.player = player;
            Refresh();
        }

        public override void Refresh()
        {

        }

        public void SetText(string text)
        {
            mainText.text = text;
        }
    }
}
