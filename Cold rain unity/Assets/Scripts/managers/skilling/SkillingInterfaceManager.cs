using Assets.Scripts.gameinterfaces.skills.artisan;
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
        public ArtisanInterface artisanInterface;

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

        public void OpenArtisanInterface(Player player)
        {
            artisanInterface.gameObject.SetActive(true);
            artisanInterface.Create(player);
        }
    }
}
