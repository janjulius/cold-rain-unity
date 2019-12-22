using Assets.Scripts;
using Assets.Scripts.saving;
using Assets.Scripts.skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : Node, SavingModule
{
    private static readonly int WARRIOR = 0, ARCHER = 1, HUNTING = 2, FISHING = 3, FARMING = 4, COOKING = 5, ARTISAN = 6;

    [SerializeField]
    public Skill[] skills;

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

        //TODO loading logic
        warriorSkill = new WarriorSkill();
        archerSkill = new ArcherSkill();
        huntingSkill = new HuntingSkill();
        fishingSkill = new FishingSkill();
        farmingSkill = new FarmingSkill();
        cookingSkill = new CookingSkill();
        artisanSkill = new ArtisanSkill();

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
