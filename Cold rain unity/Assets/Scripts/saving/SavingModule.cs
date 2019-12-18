using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.saving
{
    interface SavingModule
    {
        void Load();
        void Save();
    }
}
