using UnityEngine;
using UnityEngine.SceneManagement;

public class RunDataManager : MonoBehaviour
{
    [SerializeField] string finishScene;
    int deathCount = 0;
    int reviveCount = 0;
    

    public static RunDataManager Instance { get; private set; }


    void Awake()
    {
        Instance = this;
    }

    public void AddDeath()
    {
        deathCount++;
        CheckDeath();
    }

    public void AddRevive()
    {
        reviveCount++;
    }

    void CheckDeath()
    {
        if (deathCount - reviveCount < 2) return;

        SceneManager.LoadScene(finishScene);
    }
}
