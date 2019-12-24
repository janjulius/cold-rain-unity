using Assets.Scripts.dialogue;
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
        private Appearance appearance;
        
        public Dialogue dialogue;

        public override void Initiate()
        {
            base.Initiate();
            appearance = GetComponent<Appearance>();
        }

        public override void Interact(Entity sender)
        {
            base.Interact(sender);
            CrLogger.Log(this, $"Interacting with ({name})", CrLogger.LogType.DEFAULT);
        }

        public override void Face(FaceDirection dir)
        {
            base.Face(dir);
            appearance.UpdateAppearance(dir);
        }
    }
}
