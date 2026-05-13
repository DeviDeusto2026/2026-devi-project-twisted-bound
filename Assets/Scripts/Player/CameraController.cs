using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] float height;
    [SerializeField] float offset;
    [SerializeField] float angle;

    
    void Update()
    {
        GameObject player = GameObject.FindWithTag(playerTag);

        if (player == null) return;

        Vector3 position = player.transform.position;
        position.y += height;
        position.z += offset;

        this.transform.position = position;
        this.transform.forward = Vector3.forward;
        this.transform.Rotate(Vector3.right, angle);     
    }
}
