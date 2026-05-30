using UnityEngine;

public class Greatsword : MonoBehaviour
{
    private float maxAngle;
    private float rotationSpeed;
    private float distanceFromPlayer;
    private PlayerStats player;
    private float angle = 0;
    private Vector3 forward;


    private void Start()
    {
        forward = player.transform.forward;
        StartPosition();
    }

    private void LateUpdate()
    {
        StartPosition();

        this.gameObject.transform.RotateAround(player.transform.position, Vector3.up, angle);
        angle += rotationSpeed * Time.deltaTime;

        if (angle >= maxAngle) Destroy(this.gameObject);
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    public void SetMaxAngle(float maxAngle)
    {
        this.maxAngle = maxAngle;
    }

    public void SetPlayer(PlayerStats player)
    {
        this.player = player;
    }

    public void SetDistanceFromPlayer(float distanceFromPlayer)
    {
        this.distanceFromPlayer = distanceFromPlayer;
    }
    
    private void StartPosition()
    {
        Vector3 startPosition = player.transform.position + forward * distanceFromPlayer;
        this.transform.position = startPosition;

        float startAngle = -maxAngle / 2;
        this.gameObject.transform.RotateAround(player.transform.position, Vector3.up, startAngle);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.transform.Rotate(0, startAngle, 0);
    }
}
