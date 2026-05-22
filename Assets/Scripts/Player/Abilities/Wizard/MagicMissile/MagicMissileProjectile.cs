using UnityEngine;

public class MagicMissileProjectile : MonoBehaviour
{
    [SerializeField] float timeToLive = 5;
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        Destroy(this.gameObject, timeToLive); 
    }
}
