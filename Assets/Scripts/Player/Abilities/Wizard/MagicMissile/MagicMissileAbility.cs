using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MagicMissileAbility : Ability
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float[] damage;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private int[] numberOfProjectiles;
    [SerializeField] private float speed = 10;
    private float GetDamage()
    {
        return damage[level - 1] * playerStats.GetAttack();
    }
    private int GetNumerOfProjectiles()
    {
        return numberOfProjectiles[level - 1] + playerStats.GetNumberOfProyectiles();
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
        AbilityAttack aa = newProjectile.GetComponent<AbilityAttack>();
        aa.SetAttack(GetDamage());
        aa.playerTag = this.playerStats.gameObject.tag;

        newProjectile.GetComponent<MagicMissileProjectile>().SetSpeed(speed);
    }
}
