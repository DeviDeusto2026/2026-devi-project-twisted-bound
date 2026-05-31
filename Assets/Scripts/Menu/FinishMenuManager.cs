using System.Linq;
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
        foreach (Ability ability in runData.abilityListPlayer1)
        {
            if (ability.GetLevel() < 1) continue;
            abilitiesText += string.Format("%s: %d", ability.name, ability.GetLevel());
            abilitiesText += "\n";
        }

        abilitiesPlayer1Text.text = abilitiesText;

        string itemText = "Items: ";
        foreach (Item item in runData.itemListPlayer1)
        {
            if (item.GetLevel() < 1) continue;
            itemText += string.Format("%s: %d", item.name, item.GetLevel());
            itemText += "\n";
        }

        //Player 2
        killsPlayer2Text.text = $"Kills: {runData.killCountPlayer2}";
        deathsPlayer2Text.text = $"Deaths: {runData.deathCountPlayer2}";

        abilitiesText = "Abilities \t";
        foreach (Ability ability in runData.abilityListPlayer2)
        {
            abilitiesText += string.Format("\t%s: %d", ability.name, ability.GetLevel());
            abilitiesText += "\n";
        }

        abilitiesPlayer2Text.text = abilitiesText;

        itemText = "Items: \t";
        foreach (Item item in runData.itemListPlayer2)
        {
            itemText += string.Format("\t%s: %d", item.name, item.GetLevel());
            itemText += "\n";
        }

        //Clock
        clockText.text = $"Time Survived: {runData.clock}";
        
    }
}
