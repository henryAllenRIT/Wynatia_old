using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtility{
    public static void SetupEffect(Item.EquipmentStatusEffect statusEffect, Transform statusEffectContainer, GameObject affected, Item source = null){
        GameObject g = MonoBehaviour.Instantiate(statusEffect.effect.effectObject, statusEffectContainer);
                
                if(statusEffect.magnitude_I != 0)
                    g.GetComponent<Effect>().Activate(-1, affected, statusEffect.magnitude_I, source);
                if(statusEffect.magnitude_F != 0)
                    g.GetComponent<Effect>().Activate(-1, affected, statusEffect.magnitude_F, source);
    }
}


public interface IAffectable{
    void ModifyCurrentHealth(int amount);
    void ModifyMaxHealth(int amount);
    KeyValuePair<int, int> GetHealth();
}

public abstract class Effect : MonoBehaviour
{
    public float duration;
    public float magnitude_F = 0;
    public int magnitude_I = 0;
    protected GameObject affectedGameObject;
    protected float endTime;

    public Item effectSource;

    public void Activate(float effectDuration, GameObject gameObjectToAffect, int effectMagnitude_I, Item sourceItem = null){
        magnitude_I = effectMagnitude_I;

        InternalActivate(effectDuration, gameObjectToAffect, sourceItem);
    }

    public void Activate(float effectDuration, GameObject gameObjectToAffect, float effectMagnitude_F, Item sourceItem = null){
        magnitude_F = effectMagnitude_F;
        
        InternalActivate(effectDuration, gameObjectToAffect, sourceItem);
    }

    void InternalActivate(float effectDuration, GameObject gameObjectToAffect, Item sourceItem = null){
        duration = effectDuration;
        endTime = Time.time + duration;


        affectedGameObject = gameObjectToAffect;

        if(sourceItem)
            effectSource = sourceItem;

        SetupEffect();
        
        if(duration > 0){
            StartCoroutine(ManageDuration());
        }
    }

    protected abstract void SetupEffect();
    public abstract void Deactivate();
    

    IEnumerator ManageDuration(){
        yield return new WaitUntil(() => Time.time >= endTime);
        Deactivate();
    }

    public IEnumerator DamageOverTime(int damage, float interval, float timeOut = 0){
        float safetyTimeOut = Time.time + 600f;

        if(timeOut < Time.time - 0.01f)
            timeOut = safetyTimeOut;
       
        while(Time.time < timeOut && Time.time < safetyTimeOut){
            affectedGameObject.GetComponent<IAffectable>().ModifyCurrentHealth(Mathf.RoundToInt(-damage));
            yield return new WaitForSeconds(interval);
        }
    }
}
