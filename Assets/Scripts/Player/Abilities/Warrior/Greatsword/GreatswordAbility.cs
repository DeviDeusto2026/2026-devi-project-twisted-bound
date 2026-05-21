using UnityEngine;

public class GreatswordAbility : Ability
{
    [SerializeField] private float[] damage;
    [SerializeField] private int[] numberOfHits;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private float greatswordLifetime;
    [SerializeField] private GameObject greatsword;

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
        
        newGreatsword.GetComponent<AbilityAttack>().SetAttack(GetDamage());
        newGreatsword.GetComponent<Greatsword>().lifetime = greatswordLifetime;
        
        newGreatsword.transform.position = playerStats.transform.position + new Vector3(playerStats.transform.forward.x * newGreatsword.transform.localScale.z / 2, 0, playerStats.transform.forward.x * newGreatsword.transform.localScale.z / 2);
        newGreatsword.transform.LookAt(playerStats.transform);
    }

}
