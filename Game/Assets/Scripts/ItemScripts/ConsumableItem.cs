using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ConsumableItem : Item {

    public int HealthIncrease, StaminaRegenIncrease, StrenghtIncrease, DEFIncrease;
    
    public void Use()
    {
        StatsSystem.Instance.GainHealth(HealthIncrease);  
    }
}
