using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MagicMissileAbility : Ability
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float[] damage;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private int[] numberOfProjectiles;
    private float force = 500;
    private float GetDamage()
    {
        return damage[level] * playerStats.GetAttack();
    }
    private int GetNumerOfProjectiles()
    {
        return numberOfProjectiles[level] + playerStats.GetNumberOfProyectiles();
    }
    public override void Activate()
    {
        int nh = GetNumerOfProjectiles();
        for (int i = 0; i < nh; i++)
        {
            Invoke(nameof(ThrowAbility), timeBetweenHits * i);
        }
    }

    private void ThrowAbility()
    {
        Transform playerTransform = this.playerStats.transform;
        Vector3 position = playerTransform.position;
        position += playerTransform.forward;

        GameObject newProjectile = Instantiate(projectile, position, playerTransform.rotation);
        newProjectile.GetComponent<AbilityAttack>().SetAttack(GetDamage());

    newProjectile.GetComponent<Rigidbody>().AddForce(playerTransform.forward* force);
}
}
