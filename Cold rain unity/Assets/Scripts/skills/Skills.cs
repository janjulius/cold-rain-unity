using Assets.Scripts;
using Assets.Scripts.saving;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : Node, SavingModule
{
    public static readonly string[] Skill = { "Warrior", "Archer", "Hunting", "Fishing", "Farming", "Cooking", "Artisan" };

    public static readonly int WARRIOR = 0, ARCHER = 1, HUNTING = 2, FISHING = 3, FARMING = 4, COOKING = 5, ARTISAN = 6;

    public void Load()
    {
        throw new System.NotImplementedException();
    }

    public void Save()
    {
        throw new System.NotImplementedException();
    }
}
