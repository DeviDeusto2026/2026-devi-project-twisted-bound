using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private float experience;
    private void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    public void SetExperience(float experience)
    {
        this.experience = experience;
    }

    public float GetExperience()
    {
        return experience;
    }
}
