using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopularityManager : MonoBehaviour
{
    private static int popularity;
    public static int Popularity { get => popularity; set => popularity = value; }

    public static PopularityManager instance;
    private void Start()
    {
        Singelton();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Increase"))
        {
            popularity += 10;

            UpdatePopularity();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Decrease"))
        {
            popularity -= 10;
            UpdatePopularity();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("NegativeDoor"))
        {
            popularity -= 10;
            UpdatePopularity();
        }
        if (other.CompareTag("PositiveDoor"))
        {
            popularity += 10;
            UpdatePopularity();
        }

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
        UIManager.instance.UpdatePopularity(popularity);
        PopularityBar.instance.UpdateBar(popularity);

    }
}
