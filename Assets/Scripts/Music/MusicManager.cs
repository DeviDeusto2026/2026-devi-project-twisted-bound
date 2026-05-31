using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public void OnGameStart()
    {
        this.GetComponent<AudioSource>().Play();
    }
}
