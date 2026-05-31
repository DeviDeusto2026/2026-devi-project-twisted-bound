using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private float experience;

    public void SetExperience(float experience)
    {
        this.experience = experience;
    }

    public float GetExperience()
    {
        return experience;
    }
}
