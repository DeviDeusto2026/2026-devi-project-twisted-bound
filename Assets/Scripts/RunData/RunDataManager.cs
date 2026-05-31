using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        ResetRunData();
    }

    void ResetRunData()
    {
        runData.killCountPlayer1 = 0;
        runData.killCountPlayer2 = 0;

        runData.reviveCountPlayer1 = 0;
        runData.reviveCountPlayer2 = 0;

        runData.deathCountPlayer1 = 0;
        runData.deathCountPlayer2 = 0;

        runData.abilityListPlayer1 = new List<AbilityData>();
        runData.abilityListPlayer2 = new List<AbilityData>();

        runData.itemListPlayer1 = new List<AbilityData>();
        runData.itemListPlayer2 = new List<AbilityData>();

        runData.clock = 0;
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
            foreach(Ability ability in abilityList)
            {
                AbilityData abilityData = new AbilityData(ability.GetName(), ability.GetLevel());
                runData.abilityListPlayer1.Add(abilityData);
            }
            
        }
        else if (tag == tagPlayer2)
        {
            foreach (Ability ability in abilityList)
            {
                AbilityData abilityData = new AbilityData(ability.GetName(), ability.GetLevel());
                runData.abilityListPlayer2.Add(abilityData);
            }
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
            foreach (Item item in itemList)
            {
                AbilityData abilityData = new AbilityData(item.GetName(), item.GetLevel());
                runData.itemListPlayer1.Add(abilityData);
            }
        }
        else if (tag == tagPlayer2)
        {
            foreach (Item item in itemList)
            {
                AbilityData abilityData = new AbilityData(item.GetName(), item.GetLevel());
                runData.itemListPlayer2.Add(abilityData);
            }
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
