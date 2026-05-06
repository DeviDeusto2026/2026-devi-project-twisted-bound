using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private PlayerStats playerStats;
    private List<Ability> abilityList = new List<Ability>();

    private void Start()
    {
        playerStats = this.GetComponentInParent<PlayerStats>();
        this.abilityList.AddRange(this.GetComponentsInChildren<Ability>());
        InitiateAbilities();
    }

    void Update()
    {
        ActivateAbilities();
    }

    void InitiateAbilities()
    {
        foreach(Ability ability in abilityList){
            ability.SetPlayer(playerStats);
            //ability.SetLevel(0);
        }
    }

    void ActivateAbilities()
    {
        foreach(Ability ability in abilityList)
        {
            if (ability.GetLevel() == 0) continue;

            ability.TryActivate();

        }
    }
    public void LevelUpAbility(string abilityName)
    {
        foreach (Ability ability in abilityList)
        {
            if (ability.GetName().Equals(abilityName))
            {
                ability.LevelUp();
                break;
            }
        }
    }

    public List<Ability> GetAbilityList()
    {
        return this.abilityList;
    }
}
