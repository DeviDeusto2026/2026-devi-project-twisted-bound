using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private float attack;



    public float GetAttack()
    {
        return attack;
    }
}
