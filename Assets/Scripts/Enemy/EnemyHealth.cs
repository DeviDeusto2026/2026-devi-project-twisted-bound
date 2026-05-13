using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private EnemyStats enemyStats;

    [SerializeField] private GameObject xpOrbPrefab;

    private void Start()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        AbilityAttack abilityAttack = collider.gameObject.GetComponent<AbilityAttack>(); 

        if (abilityAttack == null) return;

        SufferAttack(abilityAttack.GetAttack());

    }

    private void SufferAttack(float attack)
    {
        enemyStats.Health -= attack;

        if (enemyStats.Health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        //Hacer cosas antes de morir (soltar experiencia, ...)
        GameObject xpOrb = Instantiate(xpOrbPrefab);
        xpOrb.transform.position = this.transform.position;

        //Destruir enemigo
        Destroy(this.gameObject);
    }



}
