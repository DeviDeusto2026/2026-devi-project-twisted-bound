using UnityEngine;

public class FlamingSphere : MonoBehaviour
{
    private PlayerStats player;
    private float distanceFromPlayer;
    private float angle = 0;
    private float rotationSpeed;
    private float sphereLifetime;

    public void SetPlayer(PlayerStats player)
    {
        this.player = player;
    }

    public void SetDistanceFromPlayer(float distanceFromPlayer)
    {
        this.distanceFromPlayer = distanceFromPlayer;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    public void SetSphereLifetime(float sphereLifetime)
    {
        this.sphereLifetime = sphereLifetime;
    }
    
    void Start()
    {
        this.transform.position = player.transform.position + new Vector3(0, 0, distanceFromPlayer);
        Destroy(this.gameObject, sphereLifetime);
    }

    private void LateUpdate()
    {
        Vector3 position = player.transform.position + new Vector3(0, 0, distanceFromPlayer);

        this.transform.position = position;
        this.gameObject.transform.RotateAround(player.transform.position, Vector3.up, angle);

        angle += rotationSpeed * Time.deltaTime;
    }
}
