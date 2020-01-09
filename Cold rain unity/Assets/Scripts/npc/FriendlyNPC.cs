using Assets.Scripts.dialogue;
using Assets.Scripts.gameinterfaces.console;
using Assets.Scripts.logger;
using Assets.Scripts.player.Equipment.visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.npc
{
    [RequireComponent(typeof(Appearance))]
    public class FriendlyNPC : NPC
    {

        protected Dialogue dialogue;
        private Appearance appearance;
        public FaceDirection SpawnFaceDir;
        public delegate void delegateEventHandler();

        public override void Initiate()
        {
            base.Initiate();
            appearance = GetComponent<Appearance>();
            appearance.FinishInit += OnAppearanceLoaded;
        }

        public void OnAppearanceLoaded()
        {
            Face(SpawnFaceDir);
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            GameConsole.Instance.SendDevMessage($"Interacting with ({name})");
            CrLogger.Log(this, $"Interacting with ({name})", CrLogger.LogType.DEFAULT);
        }

        public override void Face(FaceDirection dir)
        {
            base.Face(dir);
            appearance.UpdateAppearance(dir);
        }
    }
}
