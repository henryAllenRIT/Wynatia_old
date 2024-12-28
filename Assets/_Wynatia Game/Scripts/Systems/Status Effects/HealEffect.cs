using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    [SerializeField] int modifyAmount;
    
    IAffectable affectable;
    
    protected override void SetupEffect(){
        affectable = affectedGameObject.GetComponent<IAffectable>();

        // Use absolute value
        if(magnitude_I != 0){
            modifyAmount = magnitude_I;
        }
        // Use proportion
        else if(magnitude_F != 0){
            modifyAmount = Mathf.RoundToInt(affectable.GetHealth().Value * magnitude_F);
        }

        affectable.ModifyCurrentHealth(modifyAmount);
        
    }

    public override void Deactivate()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
