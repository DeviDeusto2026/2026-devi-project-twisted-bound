using UnityEngine;

public interface IReward
{
    public void LevelUp();
    public string GetName();
    public int GetLevel();
    public string GetImagePath();
    public string GetDescription();
}
