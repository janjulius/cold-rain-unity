using Assets.Scripts.contants;
using Assets.Scripts.dialogue;
using Assets.Scripts.logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.npc
{
    public abstract class NPC : Entity
    {
        public bool RandomlyWalk = false;

        public Vector2 WalkBoundarySW;
        public Vector2 WalkBoundaryNE;

        private float nextWalkAction = 0.0f;

        //could make these public to make them unique for every npc
        private float minWaitTime = 0.5f;
        private float maxWaitTime = 1.0f;

        public override void StartInitiate()
        {
            base.StartInitiate();
            NonPassableLayers = new string[]
            {
                "Entity", "Player", "ObjectCollision"
            };
            //WalkBoundaryNE += SpawnPosition;
            //WalkBoundarySW += SpawnPosition;
        }

        protected override void EntityUpdate()
        {
            base.EntityUpdate();
            if (RandomlyWalk)
            {
                if(!IsLocked)
                {
                    RandomWalk();
                }
            }
        }

        private void RandomWalk()
        {
            if (Time.time > nextWalkAction)
            {
                bool randomWalked = false;
                FaceDirection faceDir = (FaceDirection)Random.Range(0, 3);
                Vector2 target = GetNextTargetPosition(faceDir);
                Face(faceDir);
                if (target.x > WalkBoundarySW.x 
                    && target.x < WalkBoundaryNE.x 
                    && target.y > WalkBoundarySW.y 
                    && target.y < WalkBoundaryNE.y)
                {
                    SetDestination(target);
                    randomWalked = true;
                }
                nextWalkAction += Time.time + (randomWalked ? UnityEngine.Random.Range(minWaitTime, maxWaitTime) : -Time.time);
            }
        }
        public override void SetDestination(Vector2 loc)
        {
            if (IsLocked)
                return;
            List<RaycastHit2D> hits = Physics2D.RaycastAll(transform.position, GetVectorDirection(FaceDirection), Constants.TILE_SIZE, LayerMask.GetMask(NonPassableLayers)).ToList();
            hits.Remove(hits.FirstOrDefault(hit => hit.collider.gameObject == this.gameObject));

            if(hits.Count <= 0)
            {
                base.SetDestination(loc);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Vector3 sw = new Vector3(WalkBoundarySW.x, WalkBoundarySW.y, 100);
            Vector3 ne = new Vector3(WalkBoundaryNE.x, WalkBoundaryNE.y, 100);

            Gizmos.DrawLine(sw, new Vector3(sw.x, ne.y, 100));
            Gizmos.DrawLine(sw, new Vector3(ne.x, sw.y, 100));
            Gizmos.DrawLine(ne, new Vector3(ne.x, sw.y, 100));
            Gizmos.DrawLine(ne, new Vector3(sw.x, ne.y, 100));

        }
    }
}
