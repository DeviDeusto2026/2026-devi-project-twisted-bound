using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public readonly Stat stat;
    public readonly float power;
    public float duration;

    public Effect(Stat statEffect, float power, float duration)
    {
        this.stat = statEffect;
        this.power = power;
        this.duration = duration;
    }

    private Effect(Effect effect)
    {
        this.stat = effect.stat;
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




