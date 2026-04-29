using System.Collections.Generic;
using UnityEngine;

public class AbilityEffect : MonoBehaviour
{

    private List<Effect> effectList;


    public List<Effect> GetEffects()
    {
        return effectList;
    }

    public void SetEffects(List<Effect> effectList)
    {
        effectList = new List<Effect>(effectList.Count);
        foreach (Effect effect in effectList)
        {
            effectList.Add(effect.Copy());
        }
    }
}
