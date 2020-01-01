using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.saving
{
    public class GameLoader : Node
    {
        public override void StartInitiate()
        {
            base.StartInitiate();
            LoadGame();
        }

        void LoadGame()
        {
            GetAssembliesUsingSavingModule();
            SceneManager.LoadScene(2); //get sceneid from game
        }

        private void GetAssembliesUsingSavingModule()
        {
            Type type = typeof(SavingModule);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach(var t in types)
            {
                print("[SAVING MODULE] Loading Class: " + t.Name);
            }
        }

    }
}
