using UnityEngine;

public class MagicMissileProjectile : MonoBehaviour
{
    [SerializeField] float timeToLive = 5;
    float speed;

    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    private void Update()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>() == null) return;

        Destroy(this.gameObject);
    }
}
