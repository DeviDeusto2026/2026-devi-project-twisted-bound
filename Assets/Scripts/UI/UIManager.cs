using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject separationLine;
    [SerializeField] private GameObject xpBarPanel;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject choosePlayerPanel;
    [SerializeField] private GameObject hudPanel;

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
        separationLine.SetActive(false);
        levelUpPanel.SetActive(true);
        XpBarSetActive(false);
        hudPanel.SetActive(false);
    }


    public void CloseLevelUp()
    {
        separationLine.SetActive(true);
        levelUpPanel.SetActive(false);
        XpBarSetActive(true);
        hudPanel.SetActive(false);
    }


    private void OpenChoosePlayers()
    {
        separationLine.SetActive(false);
        xpBarPanel.SetActive(false);
        levelUpPanel.SetActive(false);
        choosePlayerPanel.SetActive(true);
        hudPanel.SetActive(false);

        eventSystem.SetActive(true);
    }

    public void StartGame()
    {
        choosePlayerPanel.SetActive(false);
        xpBarPanel.SetActive(true);
        separationLine.SetActive(true);
        hudPanel.SetActive(true);

        eventSystem.SetActive(false);
    }











    private void XpBarSetActive(bool value)
    {
        Slider xpBar = xpBarPanel.GetComponentInChildren<Slider>(true);

        Transform[] transforms = xpBar.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in transforms)
        {
            if (xpBar.transform.Equals(t)) continue;
            t.gameObject.SetActive(value);
        }
    }
}
