using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public float distance;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.red);
    }
}
