using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float healthMax = 100;
    private float healthActual = 100;
    private float velocity = 7;
    private float healthRegeneration = 0.1f;
    private float pickupAreaSize = 10;
    public bool isDead = false;

    [SerializeField] float healthRegenTimerMax = 5;
    float healthRegenTimer;
    [SerializeField] GameObject reviveSphere;

    private ItemManager itemManager;
    private EffectManager effectManager;

    private float enemyTimer = 0.5f;

    Dictionary<EnemyAttack, float> enemyDict = new Dictionary<EnemyAttack, float>();
    

    private void Awake()
    { 
        effectManager = this.gameObject.GetComponent<EffectManager>();
        itemManager = this.gameObject.GetComponentInChildren<ItemManager>();
        healthRegenTimer = healthRegenTimerMax;
    }

    private void Update()
    {
        RegenHealth();
    }

    void RegenHealth()
    {
        if (enemyDict.Keys.ToArray<EnemyAttack>().Length == 0) return;

        healthRegenTimer -= Time.deltaTime;
        if (healthRegenTimer > 0) return;

        healthRegenTimer = healthRegenTimerMax;
        if (GetHealthActual() + GetHealthRegeneration() < GetHealthMax())
        {
            healthActual += GetHealthRegeneration();
        }

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
        return (effectManager.GetPowerOf(Stat.RESISTANCE) + itemManager.GetStat(Stat.RESISTANCE));
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

    private void OnCollisionStay(Collision collision)
    {
        EnemyAttack enemyAttack = collision.gameObject.GetComponent<EnemyAttack>();

        if (enemyAttack == null) return;

        if (!enemyDict.ContainsKey(enemyAttack))
        {
            enemyDict.Add(enemyAttack, enemyTimer);
            SufferDamage(enemyAttack.GetAttack());
        }

        CheckEnemyAttack();
    }

    void CheckEnemyAttack()
    {
        List<EnemyAttack> enemyAttackList = new List<EnemyAttack>(enemyDict.Keys);

        foreach (EnemyAttack EnemyAttack in enemyAttackList)
        {
            float newTimer;

            enemyDict.TryGetValue(EnemyAttack, out newTimer);
            newTimer -= Time.deltaTime;

            if (newTimer <= 0)
            { 
                enemyDict.Remove(EnemyAttack);
                continue;
            }

            enemyDict[EnemyAttack] = newTimer;
        }
    }

    void SufferDamage(float damage)
    {
        float trueDamage = damage - GetResistance();

        if (trueDamage < 1) trueDamage = 1;

        this.healthActual -= trueDamage;
        Debug.Log($"Vida actual: {healthActual}");

        if (healthActual <= 0) Die();
    }
    public void Die()
    {
        isDead = true;
        GameObject sphere = Instantiate(reviveSphere, this.transform);
        sphere.GetComponent<Revive>().SetPlayerStats(this);
    }

    public void Revive()
    {
        isDead = false;
    }
}