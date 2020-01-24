using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.databases
{
    public class DbElement : Node
    {
        public int Id { protected set; get; }
        public string Name { protected set; get; }
    }
}
