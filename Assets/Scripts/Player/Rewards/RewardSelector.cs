
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSelector : MonoBehaviour
{
    public bool rewardChoosen = false;
    [SerializeField] List<Button> buttonList;
    public List<IReward> rewardList;

    public void ShowRewards()
    {
        for(int i = 0; i<buttonList.Count; i++)
        {
            TextMeshPro textMeshPro = buttonList[i].GetComponentInChildren<TextMeshPro>();
            string rewardName = rewardList[i].GetName();

            //textMeshPro.SetText(rewardName); //Esto se a comentado porque como algunas habilidades no tienen nombres da error al hacer pruebas
        }
    }

    public void ChooseReward(int option)
    {
        if (rewardChoosen) return;
        
        IReward reward = rewardList[option];
        reward.LevelUp();
        rewardChoosen = true;

        ColorBlock buttonColor = ColorBlock.defaultColorBlock;
        buttonColor.disabledColor = Color.green;
        buttonList[option].colors = buttonColor;

        foreach (Button button in buttonList)
        {
            button.interactable = false;
        }


    }
}
