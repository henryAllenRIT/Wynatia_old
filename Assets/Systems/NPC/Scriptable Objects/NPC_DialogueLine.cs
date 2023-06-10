using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Dialogue Line")]
public class NPC_DialogueLine : ScriptableObject
{
    [System.Serializable]
    public class ContentItem{
        public string type;
        public string subtype;
        //Specifics defaults to not applicable
        public string specifics = "n-a";

    }
    
    public string dialogue;
    [Header("If specifics or subtype are not applicable, write n-a")]
    public ContentItem[] content;
}
