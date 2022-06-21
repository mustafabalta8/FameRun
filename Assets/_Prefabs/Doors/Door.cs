using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshPro doorImpactText;

    private int[] doorImpactOptions = {5,10,15 };

    private int doorImpact;
    private void Start()
    {
        doorImpact = Random.Range(0, 3);
        if (gameObject.tag == "PositiveDoor")
        {
            doorImpactText.text = "+" + doorImpactOptions[doorImpact];
        }
        else
        {
            
            doorImpactText.text = "-" + doorImpactOptions[doorImpact];
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "PositiveDoor")
        {
            
            Popularity.instance.HandleCollidingWithDoor(doorImpactOptions[doorImpact]);
        }
        else
        {
            Popularity.instance.HandleCollidingWithDoor(-doorImpactOptions[doorImpact]);
            
        }
    }

}
