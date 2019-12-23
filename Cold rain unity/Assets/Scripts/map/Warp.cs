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

        [Header("Attatch audio source to this object")]
        public bool PlaySound;

        private AudioSource Sound;

        public override void Initiate()
        {
            base.Initiate();
            coll = GetComponent<BoxCollider2D>();
            rb = GetComponent<Rigidbody2D>();
            coll.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Sound = GetComponent<AudioSource>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (player.IsMoving)
                {
                    if (PlaySound)
                    {
                        Sound.Play();
                        Invoke("TriggerWarp", Sound.clip.length);
                    } else
                    {
                        TriggerWarp();
                    }
                }
             }
        }

        private void TriggerWarp()
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

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Light Gizmo.tiff", true);
        }
    }
}
