using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField] private Vector3 rot;
    private void Start()
    {
        transform.DORotate(rot, 2f, RotateMode.Fast).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

}
