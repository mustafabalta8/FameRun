using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField] private float verticalMove=2;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float rotationDuration=3f;
    [SerializeField] private Ease easeType;
    private void Start()
    {
        AnimateObject();
    }

    private void AnimateObject()
    {
        if (tag == "Decrease")
        {
            float rand = Random.Range(-1, 2);
            transform.DOLocalMoveX(transform.position.x + rand, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
        }
        else
        {
            transform.DOLocalMoveY(verticalMove, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(easeType);

        }
        transform.DOLocalRotate(rotation, rotationDuration, RotateMode.FastBeyond360).SetLoops(-1);
        //transform.DOLocalRotate(rotation 90, 2f, RotateMode.Fast).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
