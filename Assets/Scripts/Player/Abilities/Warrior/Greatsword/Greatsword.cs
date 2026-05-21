using UnityEngine;

public class Greatsword : MonoBehaviour
{
    public float lifetime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

}
