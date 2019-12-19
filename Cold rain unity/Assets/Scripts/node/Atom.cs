using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.node
{
    public abstract class Atom : MonoBehaviour
    {
        public abstract void Initiate();
        public abstract void StartInitiate();
    }
}
