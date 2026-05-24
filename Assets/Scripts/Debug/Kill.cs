using UnityEngine;

public class Kill : MonoBehaviour
{ 
    [SerializeField] float lifeTime;
    void Start()
    {
        Invoke(nameof(Die), lifeTime);
    }

    void Die()
    {
        this.gameObject.GetComponent<PlayerStats>().Die();
    }
}
