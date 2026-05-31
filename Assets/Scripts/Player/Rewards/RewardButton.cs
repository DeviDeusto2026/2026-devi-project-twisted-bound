using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
    [Header("Reward information")]
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text rewardName;
    [SerializeField] private Image rewardImage;
    [SerializeField] private TMP_Text description;

    [Header("Colors")]
    [SerializeField, Tooltip("The color for the button when it's chosen as the reward")] private Color chosenColor;
    [SerializeField, Tooltip("The color for the button when it's NOT chosen as the reward")] private Color notChosenColor;

    [Header("Button")]
    [SerializeField] private Button button;

    

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


    public enum DisabledColor
    {
        ChosenColor, NotChosenColor
    }


    public void SetDisabledColor(DisabledColor disabledColor)
    {
        ColorBlock cb = button.colors;
        cb.disabledColor = (disabledColor == DisabledColor.ChosenColor) ? chosenColor : notChosenColor;
        button.colors = cb;
    }
}
