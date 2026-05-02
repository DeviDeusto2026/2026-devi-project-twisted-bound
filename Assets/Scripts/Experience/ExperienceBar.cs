using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private float experience = 0;
    [SerializeField] private float level = 1;

    private const float constA = 8;
    private const float constB = -5;
    private readonly float constC = Mathf.Exp((1 - constB) / constA);

    [SerializeField] private PlayerLevelUpRewards player1;
    [SerializeField] private PlayerLevelUpRewards player2;

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
        float newLevel = Mathf.Max(Mathf.Floor(constA * Mathf.Log10(experience + constC) + constB),1);

        if (newLevel < level) return;
        
        StartCoroutine(LevelUp());
    }

    private IEnumerator LevelUp()
    {
        level++;

        //Detener el juego
        Time.timeScale = 0;

        //Enseñar habilidades y que escogan una
        player1.Activate();
        player2.Activate();

        yield return new WaitUntil(() => player1.RewardChoosen && player2.RewardChoosen);

        //Reanudar el juego
        player1.ResumeGame();
        player2.ResumeGame();
        Time.timeScale = 1;
    }
}
