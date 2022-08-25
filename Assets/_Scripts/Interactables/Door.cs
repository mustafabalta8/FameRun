using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] protected TextMeshPro doorImpactText;

    protected int[] doorImpactOptions = {5,10,15 };

    protected int doorImpact;
    

    protected virtual void SetImpactOfDoor()
    {
        doorImpact = Random.Range(0, 3);
        
    }
    public virtual void Interact()
    {
        //Popularity.instance.HandleCollidingWithDoor(doorImpactOptions[doorImpact]);
    }
    

}
