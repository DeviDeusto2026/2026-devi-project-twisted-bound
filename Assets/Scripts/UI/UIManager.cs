using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject separationLine;
    [SerializeField] private GameObject xpBarPanel;
    [SerializeField] private GameObject levelUpPanel;




    public static UIManager Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
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


}
