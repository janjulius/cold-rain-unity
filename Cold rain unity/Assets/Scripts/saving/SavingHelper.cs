using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.saving
{
    public static class SavingHelper
    {
        
        public static string ConstructPlayerPrefsShopKey(object caller, int shopId, int itemId)
        {
            return $"{caller.ToString()}:{shopId}:{itemId}";
        }

    }
}
