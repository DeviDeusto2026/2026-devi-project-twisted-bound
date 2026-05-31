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
    [SerializeField] TextMeshPro clockText;

    [Header("Player 1 info")]
    [SerializeField] TextMeshPro killsPlayer1Text;
    [SerializeField] TextMeshPro deathsPlayer1Text;
    [SerializeField] TextMeshPro RevivesPlayer1Text;
    [SerializeField] TextMeshPro abilitiesPlayer1Text;
    [SerializeField] TextMeshPro itemsPlayer1Text;

    [Header("Player 2 info")]
    [SerializeField] TextMeshPro killsPlayer2Text;
    [SerializeField] TextMeshPro deathsPlayer2Text;
    [SerializeField] TextMeshPro RevivesPlayer2Text;
    [SerializeField] TextMeshPro abilitiesPlayer2Text;
    [SerializeField] TextMeshPro itemsPlayer2Text;

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
            abilitiesText += string.Format("%s: %d", ability.name, ability.GetLevel());
            abilitiesText += "\n";
        }

        abilitiesPlayer1Text.text = abilitiesText;

        string itemText = "Items: ";
        foreach (Item item in runData.itemListPlayer1)
        {
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
