using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<Item> itemList = new List<Item>();

    void Start()
    {
        this.itemList.AddRange(this.GetComponentsInChildren<Item>());
        InitiateObjects();
    }

    void InitiateObjects()
    {
        foreach(Item item in itemList)
        {
            item.SetLevel(0);
        }
    }

    public void LevelUpObject(string itemName)
    {
        foreach (Item item in itemList)
        {
            if (item.GetName().Equals(itemName))
            {
                item.LevelUp();
                break;
            }
        }
    }

    public float GetStat(Stat stat)
    {
        foreach (Item item in itemList)
        {
            if (item.GetStat().Equals(stat))
            {
                return item.GetPower();
            }
        }

        return 0;
    }

    public List<Item> GetItemList()
    {
        return this.itemList;
    }

}
