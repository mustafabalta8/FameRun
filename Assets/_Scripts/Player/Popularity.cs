using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popularity : MonoBehaviour
{
    private static int totalPopularity;
    public static int TotalPopularity { get => totalPopularity; set => totalPopularity = value; }
    
    private int tempPopularity = 0;
    public int TempPopularity { get => tempPopularity; set => tempPopularity = value; }

    public static Popularity instance;

    [SerializeField] private Vector3 popUpPosition;
    [SerializeField] private GameObject[] positiveEmojis;
    [SerializeField] private GameObject[] negativeEmojis;
    private void Start()
    {
        Singelton();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Increase"))
        {
            tempPopularity += 2;
            
            UpdatePopularity();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Decrease"))
        {
            tempPopularity -= 2;
            
            UpdatePopularity();
            other.gameObject.SetActive(false);
        }/*
        if (other.CompareTag("NegativeDoor"))
        {
            tempPopularity -= 10;
            InstantiateVFXOnChangeInPopularity(false);
            UpdatePopularity();
        }
        if (other.CompareTag("PositiveDoor"))
        {
            tempPopularity += 10;
            InstantiateVFXOnChangeInPopularity(true);
            
        }*/

    }

    public void HandleCollidingWithDoor(int doorImpact)
    {

        tempPopularity += doorImpact;
        if (doorImpact > 0)
        {
            InstantiateVFXOnChangeInPopularity(true);
        }
        else
        {
            InstantiateVFXOnChangeInPopularity(false);
        }
        UpdatePopularity();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void UpdatePopularity()
    {
        UIManager.instance.UpdatePopularity(tempPopularity);
        PopularityBar.instance.UpdateBar(tempPopularity);
        if (tempPopularity < -2)
        {
            GameManager.instance.HandleFailing();
        }
    }
    private void InstantiateVFXOnChangeInPopularity(bool isPositive)
    {
        int randomIndex = Random.Range(0, 4);
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
