using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private EnemyStats enemyStats;

    [SerializeField] private GameObject xpOrbPrefab;
    AudioSource audioSource;

    private void Start()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
        audioSource = GetComponentInChildren<AudioSource>();
    }


    private void OnTriggerEnter(Collider collider)
    {
        AbilityAttack abilityAttack = collider.gameObject.GetComponent<AbilityAttack>(); 

        if (abilityAttack == null) return;

        SufferAttack(abilityAttack.GetAttack(), abilityAttack.playerTag);

    }

    private void SufferAttack(float attack, string playerTag)
    {
        audioSource.Play();
        enemyStats.Health -= attack;

        if (enemyStats.Health <= 0)
        {
            Die(playerTag);
        }
    }


    private void Die(string playerTag)
    {
        RunDataManager.Instance.AddKill(playerTag);

        GameObject xpOrb = Instantiate(xpOrbPrefab);
        xpOrb.transform.position = this.transform.position;


        Destroy(this.gameObject);
    }



}
