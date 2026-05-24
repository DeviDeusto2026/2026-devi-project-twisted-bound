
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSelector : MonoBehaviour
{
    [SerializeField] private List<RewardButton> buttonList;
    private List<IReward> rewardList;

    public bool rewardChoosen = false;
    

    public void SetNewRewards(List<IReward> rewards)
    {
        rewardList = rewards;
        rewardChoosen = false;

        for(int i = 0; i<buttonList.Count; i++)
        {
            RewardButton rb = buttonList[i];
            IReward reward = rewardList[i];

            rb.SetLevel(reward.GetLevel());
            rb.SetName(reward.GetName());
            rb.SetImage(reward.GetImagePath());
            rb.SetDescription(reward.GetDescription());
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
        buttonList[option].SetButtonColor(buttonColor);

        foreach (RewardButton rb in buttonList)
        {
            rb.SetInteractable(false);
        }


    }
}
