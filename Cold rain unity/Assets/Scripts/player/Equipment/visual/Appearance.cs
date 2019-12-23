using Assets.Scripts.databases.appearance;
using Assets.Scripts.extensions;
using Assets.Scripts.node;
using Assets.Scripts.player.Equipment.clothes;
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
        public int LegsId;

        public bool IsMale;

        //primitive
        private Head head;
        private LegLeft legLeft;
        private LegRight legRight;
        private ArmLeft armLeft;
        private ArmRight armRight;
        private Torso torso;

        //clothing
        private TorsoCloth torsoCloth;
        private LegLeftCloth legLeftCloth;
        private LegRightCloth legRightCloth;
        private ArmLeftCloth armLeftCloth;
        private ArmRightCloth armRightCloth;

        private Hair hair;

        private PlayerEquipVisual[] primitiveVisuals;
        private PlayerEquipVisual[] alterVisuals;

        private List<PlayerEquipVisual> allVisuals = new List<PlayerEquipVisual>();

        private HairDatabase hairDatabase;
        private LegsDatabase legsDatabase;

        public override void StartInitiate()
        {
            base.Initiate();

            hairDatabase = Camera.main.GetComponent<HairDatabase>();
            legsDatabase = Camera.main.GetComponent<LegsDatabase>();

            LoadPrimitiveVisuals();
            UpdatePrimitiveVisuals();
            
            LoadAlterVisuals();
            UpdateAlterVisuals();

            AdjustLayers(FaceDirection.DOWN);
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
            legLeftCloth = GetComponentInChildren<LegLeftCloth>();
            legRightCloth = GetComponentInChildren<LegRightCloth>();
            alterVisuals = new PlayerEquipVisual[]
            {
                hair, legLeftCloth, legRightCloth
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
            hair.EquipmentSprites = hairDatabase.GetHairStyleEquipements(HairId);
            hair.UpdateSprite(FaceDirection.DOWN);

            legLeftCloth.SetColor(BottomColor);
            legLeftCloth.EquipmentSprites = legsDatabase.GetLegStyleEquipements(LegsId).ToArray();
            legLeftCloth.UpdateSprite(FaceDirection.DOWN);

            legRightCloth.SetColor(BottomColor);
            legRightCloth.EquipmentSprites = legsDatabase.GetLegStyleEquipements(LegsId).ToArray();
            legRightCloth.spriteRenderer.flipX = true;
            legRightCloth.EquipmentSprites.SwapValues(1, 3);
            legRightCloth.UpdateSprite(FaceDirection.DOWN);
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
                    armLeft.SetLayerOrder(torsoLayer + 5);
                    armRight.SetLayerOrder(torsoLayer - 5);

                    legLeft.SetLayerOrder(torsoLayer + 5);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer - 5);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);
                    break;
                case FaceDirection.RIGHT:
                    armLeft.SetLayerOrder(torsoLayer - 5);
                    armRight.SetLayerOrder(torsoLayer + 5);

                    legLeft.SetLayerOrder(torsoLayer - 5);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer + 5);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);

                    break;
                default:
                    foreach (PlayerEquipVisual pv in primitiveVisuals)
                        pv.SetLayerOrder(0);
                    foreach (PlayerEquipVisual pv in alterVisuals)
                        pv.SetLayerOrder(1);
                    break;
            }
            hair.SetLayerOrder(head.GetLayerOrder() + 1);
        }

    }
}
