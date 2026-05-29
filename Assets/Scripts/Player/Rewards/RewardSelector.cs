
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class RewardSelector : MonoBehaviour
{
    [SerializeField] private List<RewardButton> buttonList;
    private List<IReward> rewardList;

    public bool rewardChosen = false;

    private MultiplayerEventSystem eventSystem;
    

    public void SetPlayer(GameObject player)
    {
        eventSystem = player.GetComponentInChildren<MultiplayerEventSystem>();
        eventSystem.playerRoot = this.gameObject;
    }


    public void SetNewRewards(List<IReward> rewards)
    {
        rewardList = rewards;
        rewardChosen = false;

        for(int i = 0; i<buttonList.Count; i++)
        {
            RewardButton rb = buttonList[i];
            IReward reward = rewardList[i];

            rb.SetLevel(reward.GetLevel());
            rb.SetName(reward.GetName());
            rb.SetImage(reward.GetImagePath());
            rb.SetDescription(reward.GetDescription());
        }
        
        eventSystem.SetSelectedGameObject(buttonList[0].gameObject);
    }

    public void ChooseReward(int option)
    {
        if (rewardChosen) return;
        
        IReward reward = rewardList[option];
        reward.LevelUp();
        rewardChosen = true;

        ColorBlock buttonColor = ColorBlock.defaultColorBlock;
        buttonColor.disabledColor = Color.green;
        buttonList[option].SetButtonColor(buttonColor);

        foreach (RewardButton rb in buttonList)
        {
            rb.SetInteractable(false);
        }


    }
}
