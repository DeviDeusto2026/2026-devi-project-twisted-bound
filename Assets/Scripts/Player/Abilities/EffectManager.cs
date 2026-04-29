using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public List<Effect> effectList;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effectList = new List<Effect>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseEffectDurations();
    }


    private void DecreaseEffectDurations()
    {
        foreach (Effect effect in effectList)
        {
            effect.duration -= Time.deltaTime;
        }

        effectList.RemoveAll(effect => effect.duration <= 0);
    }


    public float GetPowerOf(Effect.StatEffect statEffect)
    {
        float result = 0;
        
        foreach (Effect effect in effectList)
        {
            if (effect.statEffect != statEffect) continue;

            result += effect.power;
        }

        return result;
    }


    public void Add(List<Effect> effects)
    {
        foreach (Effect effect in effects)
        {
            effect.AddTo(effectList);
        }
    }
}
