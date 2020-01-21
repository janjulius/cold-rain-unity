using Assets.Scripts.databases.appearance;
using Assets.Scripts.extensions;
using Assets.Scripts.item;
using Assets.Scripts.node;
using Assets.Scripts.player.Equipment.clothes;
using Assets.Scripts.player.Equipment.equipment;
using Assets.Scripts.styles.hairstyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.npc.FriendlyNPC;

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
        public int BodyId;

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

        //weapons
        private MainHand mainHand;
        private OffHand offHand;
        private HeadEquipment headEquipment;
        private BodyEquipment bodyEquipment;
        private LegsEquipmentLeft legsEquipmentLeft;
        private LegsEquipmentRight legsEquipmentRight;
        
        private Hair hair;
        private Beard beard;

        private PlayerEquipVisual[] primitiveVisuals;
        private PlayerEquipVisual[] alterVisuals;
        private PlayerEquipVisual[] equipmentVisuals;

        private List<PlayerEquipVisual> allVisuals = new List<PlayerEquipVisual>();

        private HairDatabase hairDatabase;
        private BodyDatabase bodyDatabase;
        private LegsDatabase legsDatabase;
        private BeardDatabase beardDatabase;

        public event delegateEventHandler FinishInit;

        public override void StartInitiate()
        {
            base.Initiate();

            hairDatabase = Camera.main.GetComponent<HairDatabase>();
            bodyDatabase = Camera.main.GetComponent<BodyDatabase>();
            legsDatabase = Camera.main.GetComponent<LegsDatabase>();
            beardDatabase = Camera.main.GetComponent<BeardDatabase>();

            LoadPrimitiveVisuals();
            UpdatePrimitiveVisuals();
            
            LoadAlterVisuals();
            UpdateAlterVisuals();

            LoadEquipmentVisuals();

            AdjustLayers(FaceDirection.DOWN);

            FinishInit?.Invoke();
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
            beard = GetComponentInChildren<Beard>();
            legLeftCloth = GetComponentInChildren<LegLeftCloth>();
            legRightCloth = GetComponentInChildren<LegRightCloth>();
            torsoCloth = GetComponentInChildren<TorsoCloth>();
            alterVisuals = new PlayerEquipVisual[]
            {
                hair, beard, legLeftCloth, legRightCloth, torsoCloth
            };
            allVisuals.AddRange(alterVisuals);
        }

        private void LoadEquipmentVisuals()
        {
            mainHand = GetComponentInChildren<MainHand>();
            offHand = GetComponentInChildren<OffHand>();
            headEquipment = GetComponentInChildren<HeadEquipment>();
            legsEquipmentLeft = GetComponentInChildren<LegsEquipmentLeft>();
            legsEquipmentRight = GetComponentInChildren<LegsEquipmentRight>();
            bodyEquipment = GetComponentInChildren<BodyEquipment>();
            equipmentVisuals = new PlayerEquipVisual[] {
                mainHand,
                offHand,
                headEquipment,
                legsEquipmentLeft,
                legsEquipmentRight,
                bodyEquipment
            };
            allVisuals.AddRange(equipmentVisuals);

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
            print("Updating alter visuals");
            hair.SetColor(HairColor);
            hair.EquipmentSprites = hairDatabase.GetHairStyleEquipements(HairId);
            hair.UpdateSprite(FaceDirection.DOWN);

            beard.SetColor(HairColor);
            beard.EquipmentSprites = beardDatabase.GetBeardStyleEquipements(BeardId);
            beard.UpdateSprite(FaceDirection.DOWN);

            legLeftCloth.SetColor(BottomColor);
            legLeftCloth.EquipmentSprites = legsDatabase.GetLegStyleEquipements(LegsId).ToArray();
            legLeftCloth.UpdateSprite(FaceDirection.DOWN);

            legRightCloth.SetColor(BottomColor);
            legRightCloth.EquipmentSprites = legsDatabase.GetLegStyleEquipements(LegsId).ToArray();
            legRightCloth.spriteRenderer.flipX = true;
            legRightCloth.EquipmentSprites.SwapValues(1, 3);
            legRightCloth.UpdateSprite(FaceDirection.DOWN);

            torsoCloth.SetColor(TopColor);
            torsoCloth.EquipmentSprites = bodyDatabase.GetBodyStyleEquipements(BodyId).ToArray();
            torsoCloth.UpdateSprite(FaceDirection.DOWN);
        }

        public void SetEquipment(EquipmentType eqt, Item item, FaceDirection dir)
        {
            switch (eqt)
            {
                case EquipmentType.MAINHAND:
                    mainHand.EquipmentSprites = item?.EquipSprites;
                    break;
            }

            mainHand.UpdateSprite(dir);
        }

        public void UpdateAppearance(FaceDirection dir)
        {
            foreach(PlayerEquipVisual vis in allVisuals)
            {
                vis?.UpdateSprite(dir);
            }
            AdjustLayers(dir);
        }

        private void AdjustLayers(FaceDirection dir)
        {
            int torsoLayer = torso.GetLayerOrder();
            switch (dir)
            {
                case FaceDirection.LEFT:
                    armLeft.SetLayerOrder(torsoLayer + 10);
                    armRight.SetLayerOrder(torsoLayer - 10);

                    legLeft.SetLayerOrder(torsoLayer + 5);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer - 5);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);

                    torsoCloth.SetLayerOrder(torso.GetLayerOrder() + 1);

                    mainHand?.SetLayerOrder(torsoLayer + 100);
                    offHand?.SetLayerOrder(torsoLayer + 90);
                    break;
                case FaceDirection.RIGHT:
                    armLeft.SetLayerOrder(torsoLayer - 10);
                    armRight.SetLayerOrder(torsoLayer + 10);

                    legLeft.SetLayerOrder(torsoLayer - 5);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer + 5);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);

                    torsoCloth.SetLayerOrder(torso.GetLayerOrder() + 1);

                    mainHand?.SetLayerOrder(torsoLayer + 100);
                    offHand?.SetLayerOrder(torsoLayer + 90);
                    break;
                case FaceDirection.DOWN:
                    armLeft.SetLayerOrder(torsoLayer + 1);
                    armRight.SetLayerOrder(torsoLayer + 1);

                    legLeft.SetLayerOrder(torsoLayer);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);

                    torsoCloth.SetLayerOrder(torso.GetLayerOrder() + 1);

                    mainHand?.SetLayerOrder(torsoLayer + 100);
                    offHand?.SetLayerOrder(torsoLayer + 90);
                    break;
                case FaceDirection.UP:
                    armLeft.SetLayerOrder(torsoLayer - 1);
                    armRight.SetLayerOrder(torsoLayer - 1);

                    legLeft.SetLayerOrder(torsoLayer);
                    legLeftCloth.SetLayerOrder(legLeft.GetLayerOrder() + 1);

                    legRight.SetLayerOrder(torsoLayer);
                    legRightCloth.SetLayerOrder(legRight.GetLayerOrder() + 1);

                    torsoCloth.SetLayerOrder(torso.GetLayerOrder() + 1);

                    mainHand?.SetLayerOrder(torsoLayer - 100);
                    offHand?.SetLayerOrder(torsoLayer - 90);
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
