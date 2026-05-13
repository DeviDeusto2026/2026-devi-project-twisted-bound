using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [Header("Players")]
    public GameObject target;
    public GameObject player1;
    public GameObject player2;

    private EnemyStats enemyStats;

    private NavMeshAgent agent;


    void Awake()
    {
        enemyStats = this.gameObject.GetComponent<EnemyStats>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SearchTarget();
        //Rotate();
        Move();
    }



    private void SearchTarget()
    {
        float distanceToP1 = (this.transform.position - player1.transform.position).magnitude;
        float distanceToP2 = (this.transform.position - player2.transform.position).magnitude;

        if (distanceToP1 < distanceToP2)
        {
            target = player1;
        }
        else
        {
            target = player2;
        }
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
