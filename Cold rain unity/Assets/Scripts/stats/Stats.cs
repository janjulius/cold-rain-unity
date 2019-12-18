using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.stats
{
    public class Stats : Node
    {
        protected int Hitpoints { get; set; }
        protected int Energy { get; set; }
        protected int Attack { get; set; }
        protected int Defence { get; set; }
        protected int Precision { get; set; }
        protected int Speed { get; set; }

        protected int AttackSpeed { get; set; }
        protected int CritChance { get; set; }

        protected float HitpointsRegeneration { get; set; }
        protected float EnergyRegeneration { get; set; }

        public Stats(int hitpoints, int energy, int attack, int defence, int precision, int speed, int attackSpeed, int critChance, float hitpointsRegeneration, float energyRegeneration)
        {
            Hitpoints = hitpoints;
            Energy = energy;
            Attack = attack;
            Defence = defence;
            Precision = precision;
            Speed = speed;
            AttackSpeed = attackSpeed;
            CritChance = critChance;
            HitpointsRegeneration = hitpointsRegeneration;
            EnergyRegeneration = energyRegeneration;
        }

        public Stats()
        {
            Hitpoints = 0;
            Energy = 0;
            Attack = 0;
            Defence = 0;
            Precision = 0;
            Speed = 0;
            AttackSpeed = 0;
            CritChance = 0;
            HitpointsRegeneration = 0;
            EnergyRegeneration = 0;
        }
    }
}
