using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    private Vector2 movementInput;
    private Vector2 lookInput;

    private void Awake()
    {
        playerStats = this.GetComponentInChildren<PlayerStats>();
    }

    private void Update()
    {
        this.transform.position += new Vector3(movementInput.x, 0, movementInput.y) * playerStats.GetVelocity() * Time.deltaTime;

        if (lookInput == Vector2.zero) return;

        Vector3 position = new Vector3(lookInput.x, 0, lookInput.y);
        this.transform.forward = Vector3.forward;
        float angle = Vector3.SignedAngle(this.transform.forward, position, Vector3.up);
        this.transform.Rotate(Vector3.up, angle);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void OnLook(InputAction.CallbackContext ctx) => lookInput = ctx.ReadValue<Vector2>();
}
