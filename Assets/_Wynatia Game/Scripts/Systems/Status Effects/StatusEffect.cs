using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status Effect")]
public class StatusEffect : ScriptableObject
{
    public string effectName;
    public Texture2D icon;
    public string description;
    public GameObject effectObject;

    // TODO saving status effects between play sessions

}
