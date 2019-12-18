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
        public int Hitpoints { get; set; }
        public int Energy { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Precision { get; set; }
        public int Speed { get; set; }

        public int AttackSpeed { get; set; }
        public int CritChance { get; set; }

        public float HitpointsRegeneration { get; set; }
        public float EnergyRegeneration { get; set; }

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

        public static Stats operator+ (Stats a, Stats b)
        {
            return new Stats(
                a.Hitpoints + b.Hitpoints,
                a.Energy + b.Energy,
                a.Attack + b.Attack,
                a.Defence + b.Defence,
                a.Precision + b.Precision,
                a.Speed + b.Speed,
                a.AttackSpeed + b.AttackSpeed,
                a.CritChance + b.CritChance,
                a.HitpointsRegeneration + b.HitpointsRegeneration,
                a.EnergyRegeneration + b.EnergyRegeneration);
        }
    }
}
