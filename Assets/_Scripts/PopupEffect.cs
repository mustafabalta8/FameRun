using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEffect : MonoBehaviour
{
    [SerializeField] private Vector3 popUpGrowthRate;
    [SerializeField] private Vector3 direction;
    private void Start()
    {
        Destroy(gameObject, 1);
    }
    void Update()
    {
        transform.position += direction * Time.deltaTime;
        transform.localScale += popUpGrowthRate * Time.deltaTime;
    }
}
