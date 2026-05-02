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
    //Añadir gestor de objetos como atributo.

    private EffectManager effectManager;

    private void Start()
    {
        effectManager = this.gameObject.GetComponent<EffectManager>();
    }

    public float GetHealthMax()
    {
        return healthMax;
    }

    public float GetHealthActual()
    {
        return healthActual;
    }
    public float GetResistance()
    {
        return resistance * (1 + effectManager.GetPowerOf(Effect.StatEffect.RESISTANCE));
    }

    public float GetVelocity()
    {
        return velocity * (1 + effectManager.GetPowerOf(Effect.StatEffect.VELOCITY));
    }

    public float GetHealthRegeneration()
    {
        return healthRegeneration + effectManager.GetPowerOf(Effect.StatEffect.HEALTH_REGENERATION);
    }

    public float GetPickupArea()
    {
        return pickupAreaSize * (1 + effectManager.GetPowerOf(Effect.StatEffect.PICKUP_AREA));
    }


    public float GetAreaOfEffect()
    {
        return 1 + effectManager.GetPowerOf(Effect.StatEffect.AREA_OF_EFFECT);
    }


    public float GetEffectDuration()
    {
        return 1 + effectManager.GetPowerOf(Effect.StatEffect.EFFECT_DURATION);
    }

    public float GetCooldownReduction()
    {
        return 1 + effectManager.GetPowerOf(Effect.StatEffect.COOLDOWN_REDUCTION);
    }

    public int GetNumberOfProyectiles()
    {
        return (int) effectManager.GetPowerOf(Effect.StatEffect.NUMBER_OF_PROYECTILES);
    }


    public float GetAttack()
    {
        return 1 + effectManager.GetPowerOf(Effect.StatEffect.ATTACK);
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