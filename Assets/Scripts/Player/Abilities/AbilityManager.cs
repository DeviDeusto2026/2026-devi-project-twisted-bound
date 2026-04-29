using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<Ability> abilityList = new List<Ability>();

    private void Start()
    {
        abilityList[0].SetPlayer(player);
    }

    void Update()
    {
        ActivateAbilities();
    }
    void ActivateAbilities()
    {
        foreach(Ability ability in abilityList)
        {
            if (ability.GetLevel() == 0) continue;

            ability.TryActivate();

        }
    }
}
