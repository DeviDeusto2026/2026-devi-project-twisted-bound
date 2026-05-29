using UnityEngine;

public class ConeOfColdProjectile : MonoBehaviour
{
    [SerializeField] float timeToLive = 3;
    [SerializeField] float scaleSpeed = 10;
    float speed;
    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    void Update()
    { 
        this.transform.localScale += Vector3.right * scaleSpeed * Time.deltaTime;
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
