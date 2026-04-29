using Unity.Burst.CompilerServices;
using UnityEngine;

public class ExperienceBar : MonoBehaviour
{
    private float experience = 0;
    private float level = 1;

    private const float constA = 8;
    private const float constB = -5;
    private readonly float constC = Mathf.Exp((1 - constB) / constA);

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

        LevelUp();
    }
    private void LevelUp()
    {
        level++;

        //Enseñar habilidades y que escogan una. Devolver nombre
    }


}
