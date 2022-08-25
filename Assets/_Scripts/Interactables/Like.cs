using UnityEngine;
using DG.Tweening;
public class Like : Collectable
{
    private void Start()
    {
        AnimateObject();
    }
    public override void AnimateObject()
    {
        base.AnimateObject();
        transform.DOLocalMoveY(verticalMove, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
    }


}
