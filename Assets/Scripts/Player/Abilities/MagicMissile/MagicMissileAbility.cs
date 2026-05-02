using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MagicMissileAbility : Ability
{
    [SerializeField] private GameObject projectile;
    private float force = 500;

    private void Start()
    {
        this.level = 1;
        this.cooldown = 3;
    }

    public override void Activate()
    {
        Transform playerTransform = this.playerStats.transform;
        Vector3 position = playerTransform.position;
        position += playerTransform.forward;

        //Tener en cuenta daño y numero de projectiles
        
        GameObject newProjectile = Instantiate(projectile, position, playerTransform.rotation);
        newProjectile.GetComponent<AbilityAttack>().SetAttack(1);
        
        newProjectile.GetComponent<Rigidbody>().AddForce(playerTransform.forward * force);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.TryActivate();
        }
    }
}
