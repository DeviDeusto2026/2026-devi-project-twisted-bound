using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private List<Ability> abilityList = new List<Ability>();

    private void Start()
    {
        player = this.gameObject;
        InitiateAbilities();
    }

    void Update()
    {
        ActivateAbilities();
    }

    void InitiateAbilities()
    {
        foreach(Ability ability in abilityList){
            ability.SetPlayer(player);
            ability.SetLevel(0);
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
            if (ability.name.Equals(abilityName))
            {
                ability.LevelUp();
                break;
            }
        }
    }
}
