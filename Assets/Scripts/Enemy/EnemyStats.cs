using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private float attack;
    [SerializeField] private float velocity;


    private EffectManager effectManager;

    public float Health { get => health; set => health = value; }
    public float BaseAttack { get => attack; }
    public float BaseVelocity { get => velocity; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        effectManager = this.gameObject.GetComponent<EffectManager>();
    }

    public void SetStats(float health, float attack, float velocity)
    {
        this.health = health;
        this.attack = attack;
        this.velocity = velocity;
    }

    public float GetAttack()
    {
        return attack * (1 + effectManager.GetPowerOf(Stat.ATTACK));
    }

    public float GetVelocity()
    {
        return velocity * (1 + effectManager.GetPowerOf(Stat.VELOCITY));
    }

    public float GetResistanceReduction()
    {
        return 1 - effectManager.GetPowerOf(Stat.RESISTANCE);
    }


    private void OnCollisionEnter(Collision collision)
    {
        AbilityEffect abilityEffect = collision.gameObject.GetComponent<AbilityEffect>();

        if (abilityEffect == null) return;

        effectManager.Add(abilityEffect.GetEffects());
    }


}
