using UnityEngine;

public class ProjectileMagicMissile : MonoBehaviour
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
