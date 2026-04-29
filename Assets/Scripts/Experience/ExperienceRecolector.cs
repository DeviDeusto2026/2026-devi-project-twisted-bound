using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ExperienceRecolector : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private ExperienceBar experienceBar;
    private PlayerStats playerStats;

    private void Start()
    {
        experienceBar = FindAnyObjectByType<ExperienceBar>();
        playerStats = player.GetComponent<PlayerStats>();
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
        Debug.Log("Orbe recogido Trigger");
        if (experienceOrb == null) return;


        experienceBar.AddExperience(experienceOrb.GetExperience());
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ExperienceOrb experienceOrb = collision.gameObject.GetComponent<ExperienceOrb>();
        Debug.Log("Orbe recogido Collision");
        if (experienceOrb == null) return;


        experienceBar.AddExperience(experienceOrb.GetExperience());
        Destroy(collision.gameObject);
    }
}
