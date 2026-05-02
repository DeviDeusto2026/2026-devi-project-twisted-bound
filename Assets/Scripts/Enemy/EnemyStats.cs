using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health;
    [SerializeField] private float attack;
    [SerializeField] private float velocity;


    private EffectManager effectManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectManager = this.gameObject.GetComponent<EffectManager>();
    }



    public float GetAttack()
    {
        return attack * (1 + effectManager.GetPowerOf(Effect.StatEffect.ATTACK));
    }

    public float GetVelocity()
    {
        return velocity * (1 + effectManager.GetPowerOf(Effect.StatEffect.VELOCITY));
    }

    public float GetResistanceReduction()
    {
        return 1 - effectManager.GetPowerOf(Effect.StatEffect.RESISTANCE);
    }


    private void OnCollisionEnter(Collision collision)
    {
        AbilityEffect abilityEffect = collision.gameObject.GetComponent<AbilityEffect>();

        if (abilityEffect == null) return;

        effectManager.Add(abilityEffect.GetEffects());
    }


}
