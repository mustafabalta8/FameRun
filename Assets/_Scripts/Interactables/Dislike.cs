using DG.Tweening;
using UnityEngine;

public class Dislike : Collectable
{
    private void Start()
    {
        AnimateObject();
    }
    public override void AnimateObject()
    {
        base.AnimateObject();
        float rand = Random.Range(-2, 3);
        transform.DOLocalMoveX(transform.position.x + rand, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(easeType);

    }
    /*
    public override void Interact()
    {
        base.Interact();
    }*/
}
