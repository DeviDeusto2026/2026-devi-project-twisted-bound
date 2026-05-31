using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private float experience = 0;
    [SerializeField] private float level = 1;

    private const float constA = 8;
    private const float constB = -5;
    private static readonly float constC = Mathf.Exp((1 - constB) / constA);

    [Header("Player")]
    private PlayerLevelUpRewards player1;
    private PlayerLevelUpRewards player2;
    [SerializeField] string tagPlayer1;
    [SerializeField] string tagPlayer2;
    
    private Slider slider;
    private TMP_Text levelText;

    public void OnGameStart()
    {
        player1 = GameObject.FindWithTag(tagPlayer1).GetComponent<PlayerLevelUpRewards>();
        player2 = GameObject.FindWithTag(tagPlayer2).GetComponent<PlayerLevelUpRewards>();
    }

    private void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
        levelText = this.GetComponentInChildren<TMP_Text>(true);
        levelText.text = "Lv. " + level;
    }


    public void AddExperience(float experience)
    {
        SetExperience(this.GetExperience() + experience);
    }

    private float GetExperience()
    {
        return experience;
    }
    private void SetExperience(float experience)
    {
        this.experience = experience;
        CheckLevel();
    }

    private void CheckLevel()
    {
        float newLevel = Mathf.Max(constA * Mathf.Log10(experience + constC) + constB, 1);

        slider.value = newLevel - (int)newLevel;

        if (Mathf.Floor(newLevel) <= level) return;

        levelText.text = "Lv. " + level;
        StartCoroutine(LevelUp());
    }

    private IEnumerator LevelUp()
    {
        level++;

        Time.timeScale = 0;

        player1.PrepareNewRewards();
        player2.PrepareNewRewards();
        UIManager.Instance.OpenLevelUp();
        
        yield return new WaitUntil(() => player1.RewardChoosen);
        yield return new WaitUntil(() => player2.RewardChoosen);

       
        UIManager.Instance.CloseLevelUp();

        Time.timeScale = 1; 
    }
}
