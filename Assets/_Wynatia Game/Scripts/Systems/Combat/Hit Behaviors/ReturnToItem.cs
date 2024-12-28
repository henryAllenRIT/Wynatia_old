using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToItem : MonoBehaviour, ILaunchable
{
    public void Hit(Collider hit){

            GetComponent<WorldItem>().EnablePickup();
        
    }
    
}
