using UnityEngine;

public class Revive : MonoBehaviour
{
    [SerializeField] float reviveBarMax;
    float reviveBar = 0;
    [SerializeField] float gain;
    [SerializeField] float lifeTime;
    public string targetTag;
    PlayerStats playerStats;
    
    private void Start()
    {
        targetTag = (playerStats.gameObject.tag == "Wizard") ? "Warrior" : "Wizard";
        Destroy(this.gameObject, lifeTime);
    }

    public void SetPlayerStats(PlayerStats playerStats)
    {
        this.playerStats = playerStats;
    }

    private void OnTriggerStay(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag != targetTag) return;

        reviveBar += gain * Time.deltaTime;
        CheckReviveBar();
    }

    void CheckReviveBar()
    {
        if (reviveBar <= reviveBarMax) return;

        playerStats.Revive();
        Destroy(this.gameObject);
    }
}
