using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLevelUpRewards : MonoBehaviour
{
    private GameObject player;
    private const int maxAbilities = 5;
    private const int maxItems = 4;

    [Tooltip("The name of the reward selector for this player")]
    [SerializeField] private string selectorName;
    private RewardSelector rewardSelector;

    public bool RewardChoosen { get => rewardSelector.rewardChoosen; }


    public void OnGameStart()
    {
        player = this.gameObject;
        RewardSelector[] rsArray = FindObjectsByType<RewardSelector>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (RewardSelector rs in rsArray)
        {
            if (rs.CompareTag(selectorName))
            {
                rewardSelector = rs;
                break;
            }
        }
    }

    public void PrepareNewRewards()
    {
        List<Ability> abilityPool = CalculateAbilityPool();
        List<Item> itemPool = CalculateItemPool();

        List<IReward> rewardPool = new List<IReward>();
        rewardPool.AddRange(abilityPool);
        rewardPool.AddRange(itemPool);
        Debug.Log($"El size del reward es {rewardPool.Count}");
        List<IReward> rewards = CalculateReward(rewardPool);

        rewardSelector.SetNewRewards(rewards);
    }

    private List<Ability> CalculateAbilityPool()
    {
        AbilityManager abilityManager = player.GetComponent<AbilityManager>();

        if(abilityManager == null) return null;

        List<Ability> abilityPool = new List<Ability>(abilityManager.GetAbilityList());
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
        
        ItemManager itemManager = player.GetComponent<ItemManager>();

        if (itemManager == null) return null;
        
        List<Item> itemPool = new List<Item>(itemManager.GetItemList());
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
            
            int random = Random.Range(0, pool.Count() - 1);
            Debug.Log($"El random es {random}");
            Debug.Log($"El size de la lista es {pool.Count}");
            IReward reward = pool[random];

            if (!rewardList.Contains(reward))
            {
                rewardList.Add(reward);
            }
        }

        return rewardList;
    }



    
}
