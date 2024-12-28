using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IAffectable
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public int maxStamina = 100;
    public int currentStamina = 100;

    public int level = 1;

    public FloatingHealthBar healthBar;

// Intended to be equipped whenever melee weapons are unequipped; for monk characters this scriptable object could change over time, too
    public Item unarmedStrike;

    
    void Start(){
        healthBar.SetHealth(currentHealth, maxHealth);
    }


    public void ModifyCurrentHealth(int amount){
        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void ModifyMaxHealth(int amount){
        Debug.Log(amount);
        
        float oldHealthProportion = (float)currentHealth / (float)maxHealth;

        Debug.Log(oldHealthProportion);
        
        maxHealth += amount;
        currentHealth = Mathf.RoundToInt(oldHealthProportion * maxHealth);

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public KeyValuePair<int, int> GetHealth(){
        return new KeyValuePair<int, int>(maxHealth, currentHealth);
    }
}
