using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private EnemyStats enemyStats;

    private void Start()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        AbilityAttack abilityAttack = collision.gameObject.GetComponent<AbilityAttack>(); 

        if (abilityAttack == null) return;

        SufferAttack(abilityAttack.GetAttack());

    }

    private void SufferAttack(float attack)
    {
        enemyStats.health -= attack;

        if (enemyStats.health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        //Hacer cosas antes de morir (soltar experiencia, ...)

        //Destruir enemigo
        Destroy(this.gameObject);
    }



}
