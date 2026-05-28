using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject separationLine;
    [SerializeField] private GameObject xpBarPanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject choosePlayerPanel;




    public static UIManager Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        OpenChoosePlayers();
    }
    


    public void OpenLevelUp()
    {
        separationLine.SetActive(true);
        xpBarPanel.SetActive(false);
        levelUpPanel.SetActive(true);
    }


    public void CloseLevelUp()
    {
        xpBarPanel.SetActive(true);
        levelUpPanel.SetActive(false);
    }


    private void OpenChoosePlayers()
    {
        separationLine.SetActive(false);
        xpBarPanel.SetActive(false);
        levelUpPanel.SetActive(false);
        choosePlayerPanel.SetActive(true);
    }

    public void StartGame()
    {
        choosePlayerPanel.SetActive(false);
        xpBarPanel.SetActive(true);
        separationLine.SetActive(false);

    }

}
