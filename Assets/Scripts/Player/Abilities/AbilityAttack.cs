using UnityEngine;

public class AbilityAttack : MonoBehaviour
{
    [SerializeField]
    private float attack;
    public float GetAttack()
    {
        return attack;
    }

    public void SetAttack(float attack)
    {
        this.attack = attack;
    }
}
