using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item")]
public class Item : ScriptableObject
{

    public enum ItemType{
        Currency,
        Trinket,
        MagicTrinket,
        Necklace,
        Bracelet,
        Ring,
        Materials,
        Potion,
        Food,
        Weapon,
        // Small, used for bows and crossbows
        Arrows,
        // Large, used for ballistae
        Bolts,
        // Any size, can be thrown or shot out of a cannon, catapult, trebuchet, etc.
        Projectile,
        Shield,
        // MagicWeapon,
        Clothing,
        MagicClothing,
        Headwear,
        Armor,
        MagicArmor
    }

    public enum ItemEffect{
        None,
        Heal
    }
[System.Serializable]
    public class EquipmentStatusEffect{
        // public float duration;
        public float magnitude_F = 0;
        public int magnitude_I = 0;
        public StatusEffect effect;

// TODO make effects defined in the item be passive, while items defined in weapon sObjs are activated
// active effects in items would tie-in with the ability system


        public EquipmentStatusEffect(float m, StatusEffect e){
            magnitude_F = m;
            effect = e;
        }        
        public EquipmentStatusEffect(int m, StatusEffect e){
            magnitude_I = m;
            effect = e;
        }
    }

    
    public string itemName;
    public ItemType type;
    public EquipmentStatusEffect[] effects;
    public int itemLevel;
    public int value = 0;
    public GameObject worldObject;
    public string description;



    #region Weapon Paramaters
    public bool twoHanded = false;
    public MeleeWeapon meleeWeaponScriptableObject;
    public RangedWeapon rangedWeaponScriptableObject;
    public Ammunition ammunitionScriptableObject;

    #endregion
}
