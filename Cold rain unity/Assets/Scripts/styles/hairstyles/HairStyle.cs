using Assets.Scripts.databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.styles.hairstyles
{
    public class HairStyle : DbElement
    {
        public string HairName { get; private set; }

        public HairStyle(int id, string name)
        {
            Id = id;
            HairName = name;
        }
    }
}
