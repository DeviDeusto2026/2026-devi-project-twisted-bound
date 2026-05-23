using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FuryAbility : Ability
{
    //Esto le aumentará el daño, la regeneración de vida y la velocidad.Pero, reducirá su resistencia.
    //Además, hará que dure más tiempo activa la furia.
    //Duración de efectos: Para la duración de la furia activa.

    [SerializeField] float[] attack;
    [SerializeField] float[] healthRegen;
    [SerializeField] float velocity;
    [SerializeField] float[] resistanceReduction;
    [SerializeField] float[] duration;

    float GetAttack()
    {
        return attack[level - 1];
    }

    float GetHealthRegen()
    {
        return healthRegen[level - 1];
    }

    float GetVelocity()
    {
        return velocity;
    }

    float GetResistanceReduction()
    {
        return resistanceReduction[level - 1];
    }

    float GetDuration()
    {
        return duration[level - 1] * this.playerStats.GetEffectDuration();
    }

    public override void Activate()
    {
        Fury furyScript = this.playerStats.gameObject.AddComponent<Fury>();

        furyScript.SetAttack(GetAttack());
        furyScript.SetHealthRegen(GetHealthRegen());
        furyScript.SetResistanceReduction(GetResistanceReduction());
        furyScript.SetDuration(GetDuration());
    }
}
