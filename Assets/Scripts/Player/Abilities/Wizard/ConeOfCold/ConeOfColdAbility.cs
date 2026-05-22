using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfColdAbility : Ability
{
    [SerializeField] GameObject projectile;
    [SerializeField] float[] damage;
    [SerializeField] float[] slow;
    [SerializeField] float durationSlow;
    [SerializeField] float force = 500;


    private float GetDamage()
    {
        return damage[level - 1] * playerStats.GetAttack();
    }

    private Effect GetEffect()
    {
        Effect effect = new Effect(Stat.VELOCITY, slow[level-1], durationSlow);

        return effect;
    }


    public override void Activate()
    {
        Transform playerTransform = this.playerStats.transform;
        Vector3 position = playerTransform.position;
        position += playerTransform.forward;

        GameObject newProjectile = Instantiate(projectile, position, playerTransform.rotation);
        newProjectile.GetComponent<AbilityAttack>().SetAttack(GetDamage());

        List<Effect> effectList = new List<Effect>();
        effectList.Add(GetEffect());
        newProjectile.GetComponent<AbilityEffect>().SetEffects(effectList);
        newProjectile.GetComponent<Rigidbody>().AddForce(playerTransform.forward * force);
    }
}
