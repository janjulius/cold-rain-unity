using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.saving
{
    public class GameLoader : Node
    {
        public override void StartInitiate()
        {
            base.StartInitiate();
            DontDestroyOnLoad(this);
        }

        public void LoadGame()
        {
            foreach (var t in GetAssembliesUsingSavingModule())
            {
                if (t.IsSubclassOf(typeof(MonoBehaviour))
                    || t.IsSubclassOf(typeof(Node)) || t.IsSubclassOf(typeof(Atom)))
                {
                    object[] ActiveObjectInstances = FindObjectsOfType(t);
                    foreach (object activeInstance in ActiveObjectInstances)
                    {
                        MethodInfo mi = activeInstance.GetType().GetMethod("Load");
                        if (mi != null)
                        {
                            mi.Invoke(activeInstance, null);
                            GameConsole.Instance.SendDevMessage("[Load] Invoking: " + mi.ToString() + " in " + t.ToString());
                        }
                    }
                }
            }
        }

        public void SaveGame()
        {
            foreach (var t in GetAssembliesUsingSavingModule())
            {
                if (t.IsSubclassOf(typeof(MonoBehaviour)) 
                    || t.IsSubclassOf(typeof(Node)) || t.IsSubclassOf(typeof(Atom)))
                {
                    object[] ActiveObjectInstances = FindObjectsOfType(t);
                    foreach (object activeInstance in ActiveObjectInstances)
                    {
                        MethodInfo mi = activeInstance.GetType().GetMethod("Save");
                        if (mi != null)
                        {
                            mi.Invoke(activeInstance, null);
                            GameConsole.Instance.SendDevMessage("[Load] Invoking: " + mi.ToString() + " in " + t.ToString());
                        }
                    }
                }
            }
        }

        private IEnumerable<Type> GetAssembliesUsingSavingModule()
        {
            Type type = typeof(SavingModule);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            
            return types;
        }

    }
}
