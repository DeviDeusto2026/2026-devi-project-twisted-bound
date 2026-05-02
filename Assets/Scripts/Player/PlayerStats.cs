using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    private float healthMax = 100;
    private float healthActual = 100;
    private float resistance = 0;
    private float velocity = 20;
    private float healthRegeneration = 0.1f;
    private float pickupAreaSize = 10;

    private ItemManager itemManager;
    private EffectManager effectManager;

    private void Start()
    {
        effectManager = this.gameObject.GetComponent<EffectManager>();
        itemManager = this.gameObject.GetComponent<ItemManager>();
    }

    public float GetHealthMax()
    {
        return healthMax * (1 + itemManager.GetStat(Stat.HEALTH));
    }

    public float GetHealthActual()
    {
        return healthActual;
    }
    public float GetResistance()
    {
        return resistance * (1 + effectManager.GetPowerOf(Stat.RESISTANCE) + itemManager.GetStat(Stat.RESISTANCE));
    }

    public float GetVelocity()
    {
        return velocity * (1 + effectManager.GetPowerOf(Stat.VELOCITY) + itemManager.GetStat(Stat.VELOCITY));
    }

    public float GetHealthRegeneration()
    {
        return healthRegeneration + effectManager.GetPowerOf(Stat.HEALTH_REGENERATION) + itemManager.GetStat(Stat.HEALTH_REGENERATION);
    }

    public float GetPickupArea()
    {
        return pickupAreaSize * (1 + effectManager.GetPowerOf(Stat.PICKUP_AREA) + itemManager.GetStat(Stat.PICKUP_AREA));
    }


    public float GetAreaOfEffect()
    {
        return 1 + effectManager.GetPowerOf(Stat.AREA_OF_EFFECT) + itemManager.GetStat(Stat.AREA_OF_EFFECT);
    }


    public float GetEffectDuration()
    {
        return 1 + effectManager.GetPowerOf(Stat.EFFECT_DURATION) + itemManager.GetStat(Stat.EFFECT_DURATION);
    }

    public float GetCooldownReduction()
    {
        return 1 - (effectManager.GetPowerOf(Stat.COOLDOWN_REDUCTION) + itemManager.GetStat(Stat.COOLDOWN_REDUCTION));
    }

    public int GetNumberOfProyectiles()
    {
        return (int) (effectManager.GetPowerOf(Stat.NUMBER_OF_PROYECTILES) + itemManager.GetStat(Stat.NUMBER_OF_PROYECTILES));
    }


    public float GetAttack()
    {
        return 1 + effectManager.GetPowerOf(Stat.ATTACK) + itemManager.GetStat(Stat.ATTACK);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAttack enemyAttack = collision.gameObject.GetComponent<EnemyAttack>();

        if (enemyAttack == null) return;

        SufferDamage(enemyAttack.GetAttack());
    }

    void SufferDamage(float damage)
    {
        this.healthActual -= damage;

        if (healthActual <= 0) Die();
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}