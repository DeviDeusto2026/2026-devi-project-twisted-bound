using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public readonly StatEffect statEffect;
    public readonly float power;
    public float duration;


    public enum StatEffect
    {
        [Tooltip("Multiplier to the velocity stat")]
        VELOCITY,

        [Tooltip("Multiplier to the resistance stat")]
        RESISTANCE,

        [Tooltip("Multiplier to the attack stat")]
        ATTACK,

        [Tooltip("Extra health regeneration")]
        HEALTH_REGENERATION,

        [Tooltip("Multiplier to the pickup area stat")]
        PICKUP_AREA,

        [Tooltip("Multiplier to the area of effect of the abilities")]
        AREA_OF_EFFECT,

        [Tooltip("Multiplier to the effect duration")]
        EFFECT_DURATION,

        [Tooltip("Multiplier to the effect duration")]
        COOLDOWN_REDUCTION,

        [Tooltip("Extra proyectiles for the abillities")]
        NUMBER_OF_PROYECTILES,

        [Tooltip("Extra max health stat")]
        HEALTH,
    }

    public Effect(StatEffect statEffect, float power, float duration)
    {
        this.statEffect = statEffect;
        this.power = power;
        this.duration = duration;
    }

    private Effect(Effect effect)
    {
        this.statEffect = effect.statEffect;
        this.power = effect.power;
        this.duration = effect.duration;
    }


    public Effect Copy()
    {
        return new Effect(this);
    }


    public void AddTo(List<Effect> effectList)
    {
        effectList.Add(this.Copy());
    }


    
}




