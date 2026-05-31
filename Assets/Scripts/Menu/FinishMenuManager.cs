using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenuManager : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] string mainMenuScene;

    [Header("Run Data")]
    [SerializeField] RunData runData;

    [Header("Clock")]
    [SerializeField] TMP_Text clockText;

    [Header("Player 1 info")]
    [SerializeField] TMP_Text killsPlayer1Text;
    [SerializeField] TMP_Text deathsPlayer1Text;
    [SerializeField] TMP_Text RevivesPlayer1Text;
    [SerializeField] TMP_Text abilitiesPlayer1Text;
    [SerializeField] TMP_Text itemsPlayer1Text;

    [Header("Player 2 info")]
    [SerializeField] TMP_Text killsPlayer2Text;
    [SerializeField] TMP_Text deathsPlayer2Text;
    [SerializeField] TMP_Text RevivesPlayer2Text;
    [SerializeField] TMP_Text abilitiesPlayer2Text;
    [SerializeField] TMP_Text itemsPlayer2Text;

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    private void Start()
    {
        InitializeText();
    }

    void InitializeText()
    {
        //Player 1
        killsPlayer1Text.text = $"Kills: {runData.killCountPlayer1}";
        deathsPlayer1Text.text = $"Deaths: {runData.deathCountPlayer1}";

        string abilitiesText = "Abilities ";
        foreach (AbilityData ability in runData.abilityListPlayer1)
        {
            if (ability.level < 1) continue;
            abilitiesText += "\t";
            abilitiesText += ability.abilityName;
            abilitiesText += ": ";
            abilitiesText += ability.level;
            abilitiesText += "\n";
        }

        abilitiesPlayer1Text.text = abilitiesText;

        string itemText = "Items: ";
        foreach (AbilityData item in runData.itemListPlayer1)
        {
            if (item.level < 1) continue;
            itemText += "\t";
            itemText += item.abilityName;
            itemText += ": ";
            itemText += item.level;
            itemText += "\n";
        }

        itemsPlayer1Text.text = itemText;

        //Player 2
        killsPlayer2Text.text = $"Kills: {runData.killCountPlayer2}";
        deathsPlayer2Text.text = $"Deaths: {runData.deathCountPlayer2}";

        abilitiesText = "Abilities \t";
        foreach (AbilityData ability in runData.abilityListPlayer2)
        {
            if (ability.level < 1) continue;
            abilitiesText += "\t";
            abilitiesText += ability.abilityName;
            abilitiesText += ": ";
            abilitiesText += ability.level;
            abilitiesText += "\n";
        }

        abilitiesPlayer2Text.text = abilitiesText;

        itemText = "Items: \t";
        foreach (AbilityData item in runData.itemListPlayer2)
        {
            if (item.level < 1) continue;
            itemText += "\t";
            itemText += item.abilityName;
            itemText += ": ";
            itemText += item.level;
            itemText += "\n";
        }

        itemsPlayer2Text.text = itemText;

        //Clock
        int minutes = (int)runData.clock / 60;
        int seconds = (int)runData.clock % 60;
        clockText.text = $"Time Survived: {minutes}:{seconds}";
        
    }
}
