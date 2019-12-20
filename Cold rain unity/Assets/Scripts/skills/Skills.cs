using Assets.Scripts;
using Assets.Scripts.saving;
using Assets.Scripts.skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : Node, SavingModule
{
    public static readonly string[] Skill = { "Warrior", "Archer", "Hunting", "Fishing", "Farming", "Cooking", "Artisan" };

    public static readonly int WARRIOR = 0, ARCHER = 1, HUNTING = 2, FISHING = 3, FARMING = 4, COOKING = 5, ARTISAN = 6;

    [SerializeField]
    private Skill[] skills;

    private WarriorSkill warriorSkill;
    private ArcherSkill archerSkill;
    private HuntingSkill huntingSkill;
    private FishingSkill fishingSkill;
    private FarmingSkill farmingSkill;
    private CookingSkill cookingSkill;
    private ArtisanSkill artisanSkill;
    
    public override void Initiate()
    {
        base.Initiate();
        skills = new Skill[]
        {
            warriorSkill,
            archerSkill,
            huntingSkill,
            fishingSkill,
            farmingSkill,
            cookingSkill,
            artisanSkill
        };
    }


    public void Load()
    {

    }

    public void Save()
    {

    }
}
