using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStats target;
    private PlayerStats player1;
    private PlayerStats player2;

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
        //Rotate();
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


    //private void Rotate()
    //{
    //    Vector3 targetDirection = (target.transform.position - this.transform.position).normalized;

    //    if (this.transform.forward == targetDirection) return;

    //    float angle = Vector3.SignedAngle(this.transform.forward, targetDirection, Vector3.up);
    //    diseredAngle = angle;
    //    float maxAngle = Time.fixedDeltaTime * rotationSpeed;

    //    if (Mathf.Abs(angle) > maxAngle)
    //    {
    //        angle = Mathf.Sign(angle) * maxAngle;
    //    }

    //    this.transform.Rotate(Vector3.up, angle);
    //}

    //private void Move()
    //{
    //    float speedModifier = 1 / ((Mathf.Abs(diseredAngle) / 36) + 1);
    //    rb.linearVelocity = this.transform.forward * enemyStats.GetVelocity() * speedModifier;
        
    //}


    private void Move()
    {
        agent.speed = enemyStats.GetVelocity();
        agent.SetDestination(target.transform.position);
    }
}
