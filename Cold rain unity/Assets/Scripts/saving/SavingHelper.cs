using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.saving
{
    public static class SavingHelper
    {
        public static string ConstructPlayerPrefsKey(object caller, string key)=>
            $"{caller.ToString()}:{key}";
        
        public static string ConstructPlayerPrefsShopKey(object caller, int shopId, int itemId)=>
            $"{caller.ToString()}:{shopId}:{itemId}";
        
        public static string ConstructPlayerPrefsQuestKey(object caller, string questName)=>
            $"{caller.ToString()}:{questName}";
        

    }
}
