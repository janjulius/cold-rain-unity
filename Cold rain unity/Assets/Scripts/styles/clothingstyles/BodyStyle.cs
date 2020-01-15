using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.styles.clothingstyles
{
    class BodyStyle : DbElement
    {
        public BodyStyle(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
