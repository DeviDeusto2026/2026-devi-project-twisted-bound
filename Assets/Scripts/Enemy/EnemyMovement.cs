using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStats target;
    public PlayerStats player1;
    public PlayerStats player2;

    private EnemyStats enemyStats;

    private NavMeshAgent agent;


    void Awake()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SearchTarget();
        Move();
    }

    private void SearchTarget()
    {
        float distanceToP1 = (player1.isDead)? Mathf.Infinity : (this.transform.position - player1.transform.position).magnitude;
        float distanceToP2 = (player2.isDead)? Mathf.Infinity : (this.transform.position - player2.transform.position).magnitude;

        target = (distanceToP1 < distanceToP2)? player1 : player2;
    }

    public void SetPlayers(GameObject player1, GameObject player2)
    {
        this.player1 = player1.GetComponent<PlayerStats>();
        this.player2 = player2.GetComponent<PlayerStats>();
    }


    private void Move()
    {
        agent.speed = enemyStats.GetVelocity();
        agent.SetDestination(target.transform.position);
    }
}
