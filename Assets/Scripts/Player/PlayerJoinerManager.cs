using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoinerManager : MonoBehaviour
{
    bool player1Joined = false;
    bool player2Joined = false;

    [SerializeField] PlayerInputManager player1Manager;
    [SerializeField] PlayerInputManager player2Manager;

    public void OnPlayerJoined(PlayerInput playerInput) {

        if (!player1Joined)
        { 
            player1Manager.enabled = false;
            player2Manager.enabled = true;
            player1Joined = true;
        }
        else
        {
            player2Joined = true;
            player2Manager.enabled = false;
        }
    }
}
