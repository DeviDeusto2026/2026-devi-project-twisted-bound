
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardSelector : MonoBehaviour
{
    bool rewardChoosen = false;
    [SerializeField] List<Button> buttonList;
    List<IReward> rewardList;

    private void Start()
    {
        for(int i = 0; i<buttonList.Count; i++)
        {
            TextMeshPro textMeshPro = buttonList[i].GetComponentInChildren<TextMeshPro>();
            string rewardName = rewardList[i].GetName();

            textMeshPro.SetText(rewardName);
        }
    }

    public void ChooseReward(int option)
    {
        IReward reward = rewardList[option];
        reward.LevelUp();
        rewardChoosen = true;
    }
}
