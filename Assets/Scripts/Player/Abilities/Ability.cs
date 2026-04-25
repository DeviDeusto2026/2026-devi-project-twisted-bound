using System.Dynamic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    private float cooldown;
    private bool inCooldown = true;
    [SerializeField] private GameObject player;

    public void TryActivate()
    {
        if (!inCooldown) return;

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
}
