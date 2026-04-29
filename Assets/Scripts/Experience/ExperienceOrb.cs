using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    float experience;

    public void SetExperience(float experience)
    {
        this.experience = experience;
    }

    public float GetExperience()
    {
        return experience;
    }
}
