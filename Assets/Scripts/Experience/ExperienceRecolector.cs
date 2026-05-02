using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ExperienceRecolector : MonoBehaviour
{
    
    private ExperienceBar experienceBar;
    private PlayerStats playerStats;

    private void Start()
    {   
        experienceBar = FindAnyObjectByType<ExperienceBar>();
        playerStats = this.gameObject.GetComponentInParent<PlayerStats>();
    }
    private void Update()
    { 
        this.transform.localScale = Vector3.one * GetArea() * 2;
    }

    public float GetArea()
    {
        return playerStats.GetPickupArea();
    }

    private void OnTriggerEnter(Collider other)
    {
        ExperienceOrb experienceOrb = other.gameObject.GetComponent<ExperienceOrb>();
        if (experienceOrb == null) return;


        experienceBar.AddExperience(experienceOrb.GetExperience());
        Destroy(other.gameObject);
    }

}
