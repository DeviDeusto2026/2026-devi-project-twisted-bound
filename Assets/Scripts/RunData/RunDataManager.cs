using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunDataManager : MonoBehaviour
{
    [SerializeField] string finishScene;
    [SerializeField] RunData runData;
    [SerializeField] string tagPlayer1;
    [SerializeField] string tagPlayer2;

    public static RunDataManager Instance { get; private set; }


    void Awake()
    {
        Instance = this;
    }

    public void AddDeath(string tag)
    {
        if(tag == tagPlayer1)
        {
            runData.deathCountPlayer1++;
        }else if(tag == tagPlayer2)
        {
            runData.deathCountPlayer2++;
        }
        else
        {
            Debug.Log($"Se ha introducido una tag desconocida: {tag}");
        }

        CheckDeath();
    }

    public void AddRevive(string tag)
    {
        if (tag == tagPlayer1)
        {
            runData.reviveCountPlayer1++;
        }
        else if (tag == tagPlayer2)
        {
            runData.reviveCountPlayer2++;
        }
        else
        {
            Debug.Log($"Se ha introducido una tag desconocida: {tag}");
        }
    }

    void CheckDeath()
    {
        int deathCount = runData.deathCountPlayer1 + runData.deathCountPlayer2;
        int reviveCount = runData.reviveCountPlayer1 + runData.reviveCountPlayer2;

        if (deathCount - reviveCount < 2) return;

        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject gO in gameObjects)
        {
            gO.BroadcastMessage("OnGameFinish", SendMessageOptions.DontRequireReceiver);
        }

        Invoke(nameof(Finish), 3);
    }
    
    public void AddKill(string tag)
    {
        if (tag == tagPlayer1)
        {
            runData.killCountPlayer1++;
        }
        else if (tag == tagPlayer2)
        {
            runData.killCountPlayer2++;
        }
        else
        {
            Debug.Log($"Se ha introducido una tag desconocida: {tag}");
        }
    }

    public void SetClock(float clock)
    {
        runData.clock = clock;
    }

    public void SetAbilities(List<Ability> abilityList, string tag)
    {
        if (tag == tagPlayer1)
        {
            runData.abilityListPlayer1 = abilityList;
        }
        else if (tag == tagPlayer2)
        {
            runData.abilityListPlayer2 = abilityList;
        }
        else
        {
            Debug.Log($"Se ha introducido una tag desconocida: {tag}");
        }
    }

    public void SetItems(List<Item> itemList, string tag)
    {
        if (tag == tagPlayer1)
        {
            runData.itemListPlayer1 = itemList;
        }
        else if (tag == tagPlayer2)
        {
            runData.itemListPlayer2 = itemList;
        }
        else
        {
            Debug.Log($"Se ha introducido una tag desconocida: {tag}");
        }
    }

    void Finish()
    {
        SceneManager.LoadScene(finishScene);
    }
}
