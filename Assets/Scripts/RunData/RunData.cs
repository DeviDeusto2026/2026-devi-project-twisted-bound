using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunData", menuName = "Scriptable Objects/RunData")]
public class RunData : ScriptableObject
{
    public int killCountPlayer1;
    public int killCountPlayer2;

    public int reviveCountPlayer1;
    public int reviveCountPlayer2;

    public int deathCountPlayer1;
    public int deathCountPlayer2;

    public List<AbilityData> abilityListPlayer1;
    public List<AbilityData> abilityListPlayer2;

    public List<AbilityData> itemListPlayer1;
    public List<AbilityData> itemListPlayer2;

    public float clock;
}
