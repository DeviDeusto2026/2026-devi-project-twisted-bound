using UnityEngine;

public class GreatswordAbility : Ability
{
    [SerializeField] private float[] damage;
    [SerializeField] private int[] numberOfHits;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private GameObject greatsword;
    [SerializeField] private float maxAngle;
    [SerializeField] float rotationSpeed;
    [SerializeField] private float distanceFromPlayer;

    public float GetDamage()
    {
        return damage[level - 1] * playerStats.GetAttack();
    }

    public int GetNumerOfHits()
    {
        return numberOfHits[level - 1] + playerStats.GetNumberOfProyectiles();
    }

    public override void Activate()
    {
        int nh = GetNumerOfHits();
        for (int i=0; i < nh; i++)
        {
            Invoke(nameof(ThrowAbility), timeBetweenHits * i);
        }
    }


    private void ThrowAbility()
    {
        GameObject newGreatsword = Instantiate(greatsword);
        
        AbilityAttack aa = newGreatsword.GetComponent<AbilityAttack>();
        aa.SetAttack(GetDamage());
        aa.playerTag = playerStats.gameObject.tag;

        Greatsword gs = newGreatsword.GetComponent<Greatsword>();
        gs.SetPlayer(this.playerStats);
        gs.SetMaxAngle(maxAngle);
        gs.SetDistanceFromPlayer(distanceFromPlayer);
        gs.SetRotationSpeed(rotationSpeed);
    }

}
