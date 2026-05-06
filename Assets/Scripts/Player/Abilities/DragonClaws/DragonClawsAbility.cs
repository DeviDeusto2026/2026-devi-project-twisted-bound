using UnityEngine;

public class DragonClawsAbility : Ability
{
    [SerializeField] private float[] damage;
    [SerializeField] private int[] numberOfHits;
    [SerializeField] private float timeBetweenHits;
    [SerializeField] private float clawLifetime;
    [SerializeField] private GameObject claw;

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
        for (int i = 0; i < nh; i++)
        {
            Invoke(nameof(ThrowAbility), timeBetweenHits * i);
        }
    }


    private void ThrowAbility()
    {
        GameObject newClaw = Instantiate(claw);

        newClaw.GetComponent<AbilityAttack>().SetAttack(GetDamage());
        newClaw.GetComponent<DragonClaws>().lifetime = clawLifetime;

        newClaw.transform.position = playerStats.transform.position + playerStats.transform.forward* (claw.transform.localScale.z/2);
        newClaw.transform.rotation = playerStats.transform.rotation;
    }
}
