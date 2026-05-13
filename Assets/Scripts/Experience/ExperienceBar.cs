using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private float experience = 0;
    [SerializeField] private float level = 1;

    private const float constA = 8;
    private const float constB = -5;
    private readonly float constC = Mathf.Exp((1 - constB) / constA);

    [Header("Player")]
    [SerializeField] private PlayerLevelUpRewards player1;
    [SerializeField] private PlayerLevelUpRewards player2;

    private Slider slider;

    private void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
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

        if (Mathf.Floor(newLevel) < level) return;
        
        StartCoroutine(LevelUp());
    }

    private IEnumerator LevelUp()
    {
        level++; //Hacer visible el nivel

        //Detener el juego
        Time.timeScale = 0;

        //Enseñar habilidades y que escogan una
        player1.Activate();
        player2.Activate();

        yield return new WaitUntil(() => player1.RewardChoosen && player2.RewardChoosen);

        //Reanudar el juego
        player1.ResumeGame();
        player2.ResumeGame();
        Time.timeScale = 1; //Hacer que el tiempo suba proceduralmente
    }
}
