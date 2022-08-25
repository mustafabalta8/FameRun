using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveDoor : Door
{
    private void Start()
    {
        SetImpactOfDoor();
    }
    protected override void SetImpactOfDoor()
    {
        base.SetImpactOfDoor();
        doorImpactText.text = "+" + doorImpactOptions[doorImpact];       
    }
    
    public override void Interact()
    {
        base.Interact();

        Popularity.instance.HandleCollidingWithDoor(doorImpactOptions[doorImpact]);
    }
}
