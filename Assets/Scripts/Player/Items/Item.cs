using UnityEngine;

public class Item : MonoBehaviour, IReward
{
    string itemName;
    Effect.StatEffect stat;
    int level;
    float power;

    
    public Effect.StatEffect GetStat()
    {
        return stat;
    }
    public float GetPower()
    {
        return level * power;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void LevelUp()
    {
        this.level = this.GetLevel() + 1;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public string GetName()
    {
        return this.itemName;
    }
}
