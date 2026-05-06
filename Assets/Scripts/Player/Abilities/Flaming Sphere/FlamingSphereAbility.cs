using UnityEngine;

public class FlamingSphereAbility : Ability
{
    [SerializeField] private float[] damage;
    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float[] sphereLifetime;
    [SerializeField] private GameObject flamingSphere;

    public float GetDamage()
    {
        return damage[level - 1] * playerStats.GetAttack();
    }

    public float GetDistanceFromPlayer()
    {
        return distanceFromPlayer * playerStats.GetAreaOfEffect();
    }
    public float GetSphereLifetime()
    {
        return sphereLifetime[level - 1] * playerStats.GetEffectDuration();
    }

    public override void Activate()
    {
        Debug.Log("He sido activada");
        Transform playerTransform = this.playerStats.transform;
        Vector3 position = playerTransform.position;
        position += playerTransform.forward;

        GameObject newSphere= Instantiate(flamingSphere, position, playerTransform.rotation);
        newSphere.GetComponent<AbilityAttack>().SetAttack(GetDamage());

        FlamingSphere fs = newSphere.GetComponent<FlamingSphere>();
        fs.SetDistanceFromPlayer(GetDistanceFromPlayer());
        fs.SetPlayer(this.playerStats);
        fs.SetRotationSpeed(rotationSpeed);
        fs.SetSphereLifetime(GetSphereLifetime());
    }
}
