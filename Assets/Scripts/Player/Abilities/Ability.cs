using System.Dynamic;
using UnityEngine;

public abstract class Ability : MonoBehaviour, IReward
{
    public const int maxLevel = 7;

    [SerializeField] protected string abilityName;
    [SerializeField] protected int level;
    [SerializeField] protected float cooldown;
    protected bool inCooldown = true;
    protected PlayerStats playerStats;
    [SerializeField] protected string imagePath;
    [SerializeField] protected string description;
    [SerializeField] protected AudioSource audioSource;

    private void Start()
    {
        Invoke(nameof(Abilitate), cooldown);
        this.audioSource = this.GetComponentInChildren<AudioSource>();
    }

    public void TryActivate()
    {
        if (inCooldown) return;

        Activate();
        if(audioSource != null) audioSource.Play();
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
        return cooldown * playerStats.GetCooldownReduction();
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

    public void SetPlayer(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    public string GetName()
    {
        return this.abilityName;
    }

    public string GetImagePath()
    {
        string path = "AbilityImages/";
        path += imagePath;
        return path;
    }
    public string GetDescription()
    {
        return this.description;
    }
}
