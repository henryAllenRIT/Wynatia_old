using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : Effect
{
    // [SerializeField] GameObject particleEffect;


    protected override void SetupEffect(){
        StartCoroutine(DamageOverTime(magnitude_I, 1f, endTime));

        // Instantiate(particleEffect, transform);
    }

    public override void Deactivate()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

}
