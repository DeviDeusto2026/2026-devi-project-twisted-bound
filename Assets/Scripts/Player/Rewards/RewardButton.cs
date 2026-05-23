using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text rewardName;
    [SerializeField] private Image rewardImage;
    [SerializeField] private TMP_Text description;

    private Button button;

    private void Awake()
    {
        button = this.GetComponent<Button>();
    }


    public void SetLevel(int actualLevel)
    {
        levelText.text = (actualLevel != 0) ? "Lv." + (actualLevel+1) : "NEW"; 
    }

    public void SetName(string name)
    {
        rewardName.text = name;
    }


    public void SetImage(string imagePath)
    {
        rewardImage.sprite = Resources.Load<Sprite>(imagePath);
    }

    public void SetDescription(string desc)
    {
        description.text = desc;
    }

    public void SetInteractable(bool interactable)
    {
        button.interactable = interactable;
    }

    public void SetButtonColor(ColorBlock color)
    {
        button.colors = color;
    }
}
