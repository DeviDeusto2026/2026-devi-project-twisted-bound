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
        ATTACK
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




