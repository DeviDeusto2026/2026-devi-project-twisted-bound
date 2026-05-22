using UnityEngine;

public class Cone : MonoBehaviour
{
    [SerializeField] float timeToLive = 3;
    [SerializeField] float speed = 1;
    void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    void Update()
    { 
        this.transform.localScale += Vector3.right * speed * Time.deltaTime;
    }
}
