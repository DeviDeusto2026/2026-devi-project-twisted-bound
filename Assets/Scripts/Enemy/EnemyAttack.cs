using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private EnemyStats enemyStats;

    private void Start()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
    }

    public float GetAttack()
    {
        return enemyStats.GetAttack();
    }
}
