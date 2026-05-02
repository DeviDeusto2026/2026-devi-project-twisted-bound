using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private List<Item> objectList = new List<Item>();

    void Start()
    {
        InitiateObjects();
    }

    void InitiateObjects()
    {
        foreach(Item item in objectList)
        {
            item.SetLevel(0);
        }
    }

    public void LevelUpObject(string itemName)
    {
        foreach (Item item in objectList)
        {
            if (item.GetName().Equals(itemName))
            {
                item.LevelUp();
                break;
            }
        }
    }

    public float GetStat(Effect.StatEffect stat)
    {
        foreach (Item item in objectList)
        {
            if (item.GetStat().Equals(stat))
            {
                return item.GetPower();
            }
        }

        return 0;
    }

}
