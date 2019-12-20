using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.container
{
    public class ContainerDisplay : Node
    {
        public override void Initiate()
        {
            base.Initiate();
            Create();
        }

        public virtual void Create()
        {

        }

        public virtual void Refresh(Container container)
        {

        }

    }
}
