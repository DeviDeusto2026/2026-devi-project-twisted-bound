using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject separationLine;
    [SerializeField] private GameObject xpBarPanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject choosePlayerPanel;

    [Header("Event System")]
    [SerializeField] private GameObject eventSystem;




    public static UIManager Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        OpenChoosePlayers();
    }
    


    public void OpenLevelUp()
    {
        separationLine.SetActive(true);
        levelUpPanel.SetActive(true);
    }


    public void CloseLevelUp()
    {
        levelUpPanel.SetActive(false);
    }


    private void OpenChoosePlayers()
    {
        separationLine.SetActive(false);
        xpBarPanel.SetActive(false);
        levelUpPanel.SetActive(false);
        choosePlayerPanel.SetActive(true);

        eventSystem.SetActive(true);
    }

    public void StartGame()
    {
        choosePlayerPanel.SetActive(false);
        xpBarPanel.SetActive(true);
        separationLine.SetActive(true);

        eventSystem.SetActive(false);
    }

}
