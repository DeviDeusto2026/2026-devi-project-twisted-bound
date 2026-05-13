using UnityEngine;

public class DragonClaws : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

}
