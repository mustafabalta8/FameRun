using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TabToPlayButton : MonoBehaviour
{
    [SerializeField] float growthAmount=1.2f;
    [SerializeField] float duration = 0.8f;
    private void OnEnable()
    {
        transform.DOScale(transform.localScale * growthAmount, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
