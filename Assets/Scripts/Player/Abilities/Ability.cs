using System.Dynamic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public const int maxLevel = 7;

    protected string abilityName;
    protected int level;
    protected float cooldown;
    protected bool inCooldown = false;
    [SerializeField] protected GameObject player;

    public void TryActivate()
    {
        if (inCooldown) return;

        Activate();
        inCooldown = true;
        Invoke(nameof(Abilitate), GetCooldown());
    }

    public abstract void Activate();
    void Abilitate()
    {
        inCooldown = false;
    }

    float GetCooldown()
    {
        return cooldown;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int level)
    {
        if (level < 0 && level > maxLevel) return;

        this.level = level;
    }
    
    public void LevelUp()
    {
        this.level = this.GetLevel() + 1;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
