using UnityEngine;

public enum Stat
{   
    [Tooltip("Extra max health stat")]
    HEALTH,

    [Tooltip("Multiplier to the attack stat")]
    ATTACK,

    [Tooltip("Multiplier to the velocity stat")]
    VELOCITY,

    [Tooltip("Multiplier to the resistance stat")]
    RESISTANCE,

    [Tooltip("Extra health regeneration")]
    HEALTH_REGENERATION,

    [Tooltip("Multiplier to the pickup area stat")]
    PICKUP_AREA,

    [Tooltip("Multiplier to the area of effect of the abilities")]
    AREA_OF_EFFECT,

    [Tooltip("Multiplier to the effect duration")]
    EFFECT_DURATION,

    [Tooltip("Multiplier to the effect duration")]
    COOLDOWN_REDUCTION,

    [Tooltip("Extra proyectiles for the abillities")]
    NUMBER_OF_PROYECTILES
}
