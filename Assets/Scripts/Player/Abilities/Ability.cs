using System.Dynamic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
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

    public float GetLevel()
    {
        return level;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
