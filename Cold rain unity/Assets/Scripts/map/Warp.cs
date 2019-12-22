using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.map
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Warp : Node
    {
        private BoxCollider2D coll;
        private Rigidbody2D rb;
        private Player player;

        public bool GoesToOtherScene;
        public int SceneId = 0;

        public Vector2 endLocation;

        public override void Initiate()
        {
            base.Initiate();
            coll = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            coll.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (player.IsMoving)
                {
                    if (GoesToOtherScene)
                    {
                        player.LoadIntoScene(SceneId, endLocation);
                    }
                    else
                    {
                        player.SetLocation(endLocation);
                    }
                }
             }
        }
    }
}
