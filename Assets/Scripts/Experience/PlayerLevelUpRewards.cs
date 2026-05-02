using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelUpRewards : MonoBehaviour
{
    GameObject player;
    int maxAbilities = 5;
    int maxItems = 4;
    
    public void Activate()
    {
        List<Ability> abilityPool = CalculateAbilityPool();
        List<Item> itemPool = CalculateItemPool();

        List<IReward> rewardPool = new List<IReward>();
        rewardPool.AddRange(abilityPool);
        rewardPool.AddRange(itemPool);

        List<IReward> rewards = CalculateReward(rewardPool);
    }

    private List<Ability> CalculateAbilityPool()
    {
        List<Ability> abilityPool = new List<Ability>();
        AbilityManager abilityManager = player.GetComponent<AbilityManager>();

        if(abilityManager == null) return null;

        List<Ability> leveledUpAbilities = new List<Ability>();
        foreach (Ability ability in abilityManager.GetAbilityList())
        {
            if(ability.GetLevel() > 0)
            {
                leveledUpAbilities.Add(ability);
            }
        }

        if(leveledUpAbilities.Count() < maxAbilities)
        {
            return abilityPool;
        } else
        {
            return leveledUpAbilities;
        }
    }

    private List<Item> CalculateItemPool()
    {
        List<Item> itemPool = new List<Item>();
        ItemManager itemManager = player.GetComponent<ItemManager>();

        if (itemManager == null) return null;

        List<Item> leveledUpItems = new List<Item>();
        foreach(Item item in itemManager.GetItemList())
        {
            if(item.GetLevel() > 0)
            {
                leveledUpItems.Add(item);
            }
        }

        if(leveledUpItems.Count() < maxItems)
        {
            return itemPool;
        }
        else
        {
            return leveledUpItems;
        }
    }

    private List<IReward> CalculateReward(List<IReward> pool)
    {
        List<IReward> rewardList = new List<IReward>();
        int listMaxSize = 3;

        while(rewardList.Count < listMaxSize)
        {
            int random = Random.Range(0, pool.Count());
            IReward reward = pool[random];

            if (!rewardList.Contains(reward))
            {
                rewardList.Add(reward);
            }
        }

        return rewardList;
    }

    
    //Sacar 3 recompensas
}
