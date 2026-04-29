using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 moveDirection;

    [SerializeField] private float velocity;    
    [SerializeField] private InputActionReference move;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector3>();
        moveDirection = moveDirection.normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector3(moveDirection.x * velocity, 0, moveDirection.z * velocity);
    }
}
