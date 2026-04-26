using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]
    private float health;


    private void OnCollisionEnter(Collision collision)
    {
        AbilityAttack abilityAttack = collision.gameObject.GetComponent<AbilityAttack>(); 

        if (abilityAttack == null) return;

        SufferAttack(abilityAttack.GetAttack());

    }

    private void SufferAttack(float attack)
    {
        health -= attack;

        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        //Hacer cosas antes de morir (soltar experiencia, ...)

        //Destruir enemigo
        Destroy(this.gameObject);
    }



}
