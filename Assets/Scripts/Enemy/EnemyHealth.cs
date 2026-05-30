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

        SufferAttack(abilityAttack.GetAttack(), abilityAttack.playerTag);

    }

    private void SufferAttack(float attack, string playerTag)
    {
        enemyStats.Health -= attack;

        if (enemyStats.Health <= 0)
        {
            Die(playerTag);
        }
    }


    private void Die(string playerTag)
    {
        RunDataManager.Instance.AddKill(playerTag);

        //Hacer cosas antes de morir (soltar experiencia, ...)
        GameObject xpOrb = Instantiate(xpOrbPrefab);
        xpOrb.transform.position = this.transform.position;

        //Destruir enemigo
        Destroy(this.gameObject);
    }



}
