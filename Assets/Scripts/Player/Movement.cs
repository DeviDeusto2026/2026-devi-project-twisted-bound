using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 moveDirection;

    [SerializeField] private float speed;    
    [SerializeField] private InputActionReference move;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(move.action.ReadValue<Vector3>());
        moveDirection = move.action.ReadValue<Vector3>();
        moveDirection = moveDirection.normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector3(moveDirection.x * speed, 0, moveDirection.z * speed);
    }
}
