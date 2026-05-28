using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoinerManager : MonoBehaviour
{
    public bool player1Joined = false;
    public bool player2Joined = false;

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



    public void ResetPlayerJoiner()
    {
        player1Joined = false;
        player2Joined = false;

        player1Manager.enabled = true;
        player2Manager.enabled = false;

        PlayerStats[] players = FindObjectsByType<PlayerStats>(FindObjectsSortMode.None);
        foreach (PlayerStats player in players)
        {
            Destroy(player.gameObject);
        }

    }
}
