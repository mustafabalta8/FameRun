
using UnityEngine;
using System;

public class Popularity : Singleton<Popularity>
{
    private static int totalPopularity;
    public static int TotalPopularity { get => totalPopularity; set => totalPopularity = value; }
    
    private int tempPopularity = 0;
    public int TempPopularity { get => tempPopularity; set => tempPopularity = value; }


    [SerializeField] private Vector3 popUpPosition;
    [SerializeField] private GameObject[] positiveEmojis;
    [SerializeField] private GameObject[] negativeEmojis;



    private void OnTriggerEnter(Collider other)
    {
        var interactible = other.GetComponent<IInteractable>();
        if (interactible != null)
        {
            interactible.Interact();
        }      

    }

    public void HandleCollidingWithDoor(int doorImpact)
    {

        //tempPopularity += doorImpact;
        if (doorImpact > 0)
        {
            InstantiateVFXOnChangeInPopularity(true);
        }
        else
        {
            InstantiateVFXOnChangeInPopularity(false);
        }
        UpdatePopularity(doorImpact);
    }

    public void UpdatePopularity( int amount)
    {
        tempPopularity += amount;
        UIManager.instance.UpdatePopularity(tempPopularity);
        PopularityBar.instance.UpdateBar(tempPopularity);
        if (tempPopularity < -2)
        {
            GameManager.instance.HandleFailing();
        }
    }
    private void InstantiateVFXOnChangeInPopularity(bool isPositive)
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);
        if (isPositive)
        {

            Instantiate(positiveEmojis[randomIndex], transform.position+popUpPosition, positiveEmojis[randomIndex].transform.rotation);
        }
        else
        {
            Instantiate(negativeEmojis[randomIndex], transform.position + popUpPosition, negativeEmojis[randomIndex].transform.rotation);
        }
    }
}
