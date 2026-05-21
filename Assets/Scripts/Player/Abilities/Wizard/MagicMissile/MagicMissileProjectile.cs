using UnityEngine;

public class MagicMissileProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        Destroy(this.gameObject, 5); 
    }
}
