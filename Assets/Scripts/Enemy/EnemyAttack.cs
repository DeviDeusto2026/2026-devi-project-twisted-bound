using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private int attack;



    public int GetAttack()
    {
        return attack;
    }
}
