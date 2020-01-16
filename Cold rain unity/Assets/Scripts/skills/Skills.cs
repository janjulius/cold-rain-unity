using Assets.Scripts;
using Assets.Scripts.logger;
using Assets.Scripts.saving;
using Assets.Scripts.skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : Node, SavingModule
{

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
        warriorSkill = gameObject.AddComponent<WarriorSkill>();
        archerSkill = gameObject.AddComponent< ArcherSkill>();
        huntingSkill = gameObject.AddComponent< HuntingSkill>();
        fishingSkill = gameObject.AddComponent< FishingSkill>();
        farmingSkill = gameObject.AddComponent< FarmingSkill>();
        cookingSkill = gameObject.AddComponent< CookingSkill>();
        artisanSkill = gameObject.AddComponent< ArtisanSkill>();

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
    
    public Skill GetSkill(int id) =>
        skills[id];

    public Skill GetSkill(SKILLS skill) =>
        GetSkill((int)skill);
    
    public void Load()
    {

    }

    public void Save()
    {

    }
}
