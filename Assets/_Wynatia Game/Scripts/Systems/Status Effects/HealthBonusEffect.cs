using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonusEffect : Effect
{
    [SerializeField] int originalHealth;
    [SerializeField] int modifyAmount;
    IAffectable affectable;

    protected override void SetupEffect(){
        affectable = affectedGameObject.GetComponent<IAffectable>();
        originalHealth = affectable.GetHealth().Value;

        // Use absolute value
        if(magnitude_I != 0){
            modifyAmount = magnitude_I;
        }
        // Use proportion
        else if(magnitude_F != 0){
            modifyAmount = Mathf.RoundToInt(originalHealth * magnitude_F);
        }

        affectable.ModifyMaxHealth(modifyAmount);
        
    }

    public override void Deactivate()
    {
        affectable.ModifyMaxHealth(-modifyAmount);
        
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
