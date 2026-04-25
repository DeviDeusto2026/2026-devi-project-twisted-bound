using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class Direction : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        var(succes, position) = GetMousePosition();
        if (!succes) return;

        var direction = position - transform.position;

        //Se mueve la posicion Y a una fija
        direction.y = 0;

        transform.forward = direction;

    }

    private (bool succes, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity))
        {
            return (succes: true, position: hitInfo.point);
        }
        else
        {
            return (succes: false, position: Vector3.zero);
        }
    }
}
