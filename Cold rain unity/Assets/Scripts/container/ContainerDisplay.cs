using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.container
{
    public class ContainerDisplay : GameInterface
    {
        protected Container myContainer;

        public override void Create(Player player)
        {
            this.player = player;
        }

        public override void Refresh()
        {

        }

        public override void Initiate()
        {
            base.Initiate();
        }


        public virtual void Refresh(Container container)
        {

        }

        public Container GetContainer()
        {
            return myContainer;
        }

    }
}
