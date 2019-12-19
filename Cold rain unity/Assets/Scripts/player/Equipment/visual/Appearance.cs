using Assets.Scripts.node;
using Assets.Scripts.styles.hairstyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.player.Equipment.visual
{
    public class Appearance : Node
    {
        public Color SkinColor;
        public Color HairColor;

        public Color TopColor;
        public Color BottomColor;

        public int HairId;
        public int BeardId;

        public bool IsMale;

        private Head head;
        private LegLeft legLeft;
        private LegRight legRight;
        private ArmLeft armLeft;
        private ArmRight armRight;
        private Torso torso;

        private Hair hair;

        private PlayerEquipVisual[] primitiveVisuals;
        private PlayerEquipVisual[] alterVisuals;

        private List<PlayerEquipVisual> allVisuals = new List<PlayerEquipVisual>();

        public override void Initiate()
        {
            base.Initiate();

            LoadPrimitiveVisuals();
            UpdatePrimitiveVisuals();
            
            LoadAlterVisuals();
            UpdateAlterVisuals();
        }

        private void LoadPrimitiveVisuals()
        {
            head = GetComponentInChildren<Head>();
            legLeft = GetComponentInChildren<LegLeft>();
            legRight = GetComponentInChildren<LegRight>();
            armLeft = GetComponentInChildren<ArmLeft>();
            armRight = GetComponentInChildren<ArmRight>();
            torso = GetComponentInChildren<Torso>();
            primitiveVisuals = new PlayerEquipVisual[]
            {
                head,legLeft,legRight,armLeft,armRight,torso
            };
            allVisuals.AddRange(primitiveVisuals);
        }

        private void LoadAlterVisuals()
        {
            hair = GetComponentInChildren<Hair>();
            alterVisuals = new PlayerEquipVisual[]
            {
                hair
            };
            allVisuals.AddRange(alterVisuals);
        }

        private void UpdatePrimitiveVisuals()
        {
            foreach (PlayerEquipVisual pev in primitiveVisuals)
            {
                pev.SetColor(SkinColor);
            }
        }

        private void UpdateAlterVisuals()
        {
            hair.SetColor(HairColor);
            print("Updating alter visuals");
            hair.EquipmentSprites = Camera.main.GetComponent<HairDatabase>().GetHairStyleEquipements(HairId);
            hair.UpdateSprite(FaceDirection.DOWN);
        }

        public void UpdateAppearance(FaceDirection dir)
        {
            foreach(PlayerEquipVisual vis in allVisuals)
            {
                vis.UpdateSprite(dir);
            }
            AdjustLayers(dir);
        }

        private void AdjustLayers(FaceDirection dir)
        {
            int torsoLayer = torso.GetLayerOrder();
            switch (dir)
            {
                case FaceDirection.LEFT:
                    armLeft.SetLayerOrder(torsoLayer + 1);
                    armRight.SetLayerOrder(torsoLayer - 1);
                    legLeft.SetLayerOrder(torsoLayer + 1);
                    legRight.SetLayerOrder(torsoLayer - 1);
                    break;
                case FaceDirection.RIGHT:
                    armLeft.SetLayerOrder(torsoLayer - 1);
                    armRight.SetLayerOrder(torsoLayer + 1);
                    legLeft.SetLayerOrder(torsoLayer - 1);
                    legRight.SetLayerOrder(torsoLayer + 1);
                    break;
                default:
                    foreach (PlayerEquipVisual pv in primitiveVisuals)
                        pv.SetLayerOrder(0);
                    break;
            }
            hair.SetLayerOrder(head.GetLayerOrder() + 1);
        }

    }
}
