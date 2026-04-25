using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    private float healthMax = 100;
    private float healthActual = 100;
    private float resistance = 0;
    private float velocity = 20;
    private float healthRegeneration = 0.1f;
    private float pickupAreaSize = 10;
    //Añadir gestor de objetos como atributo.

    public float GetHealthMax()
    {
        return healthMax;
    }

    public float GetHealthActual()
    {
        return healthActual;
    }
    public float GetResistance()
    {
        return resistance;
    }

    public float GetVelocity()
    {
        return velocity;
    }

    public float GetHealthRegeneration()
    {
        return healthRegeneration;
    }

    public float GetPickupArea()
    {
        return pickupAreaSize;
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAttack enemyAttack = collision.gameObject.GetComponent<EnemyAttack>();

        if (enemyAttack == null) return;

        SufferDamage(enemyAttack.GetAttack());
    }

    void SufferDamage(float damage)
    {
        this.healthActual -= damage;

        if (healthActual <= 0) Die();
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}