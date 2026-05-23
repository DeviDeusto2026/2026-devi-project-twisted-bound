using System.Collections.Generic;
using UnityEngine;

public class Fury : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color originalColor;
    Color furyColor = Color.red;
    float timer;
    float timerMax;

    float attack;
    float healthRegen;
    float velocity;
    float resistanceReduction;
    float duration;

    void Start()
    {
        Destroy(this, duration);
        meshRenderer = this.GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
        timerMax = duration / 16;
        timer = timerMax;
        GiveEffects();
    }

    private void OnDestroy()
    {
        meshRenderer.material.color = originalColor;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer >= 0) return;

        timer = timerMax;

        if (meshRenderer.material.color == originalColor)
        {
            meshRenderer.material.color = furyColor;
        }
        else
        {
            meshRenderer.material.color = originalColor;
        }
    }

    public void SetAttack(float attack)
    {
        this.attack = attack;
    }

    public void SetHealthRegen(float healthRegen)
    {
        this.healthRegen = healthRegen;
    }

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    public void SetResistanceReduction(float resistanceReduction)
    {
        this.resistanceReduction = resistanceReduction;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
    void GiveEffects() 
    {
        Effect effectAttack = new Effect(Stat.ATTACK, attack, duration);
        Effect effectHealthRegen = new Effect(Stat.HEALTH_REGENERATION, healthRegen, duration);
        Effect effectVelocity = new Effect(Stat.VELOCITY, velocity, duration);
        Effect effectResistanceReduction = new Effect(Stat.RESISTANCE, resistanceReduction, duration);
        List<Effect> effectList = new List<Effect>();

        effectList.Add(effectAttack);
        effectList.Add(effectHealthRegen);
        effectList.Add(effectVelocity);
        effectList.Add(effectResistanceReduction);

        this.GetComponentInParent<EffectManager>().Add(effectList);
    }
}