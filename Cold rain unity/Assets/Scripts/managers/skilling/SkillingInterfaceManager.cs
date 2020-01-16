using Assets.Scripts.gameinterfaces.skills.cooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.managers.skilling
{
    public class SkillingInterfaceManager : Node
    {
        public CookingInterface cookingInterface;

        public override void Initiate()
        {
            base.Initiate();
            DontDestroyOnLoad(this);
        }

        public void OpenCookingInterface(Player player)
        {
            cookingInterface.gameObject.SetActive(true);
            cookingInterface.Create(player);
        }
    }
}
