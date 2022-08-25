using UnityEngine;
using DG.Tweening;
public class Collectable : MonoBehaviour, ICollectable, IInteractable
{
    [SerializeField]
    protected int popularityEffectAmount=2;
    [Header("Animation Design")]
    [SerializeField] protected float verticalMove = 2;
    [SerializeField] protected Vector3 rotation;
    [SerializeField] protected float rotationDuration = 3f;
    [SerializeField] protected Ease easeType;


    public virtual void AnimateObject()
    {
        transform.DOLocalRotate(rotation, rotationDuration, RotateMode.FastBeyond360).SetLoops(-1);
    }

    public virtual void Interact()
    {
        gameObject.SetActive(false);
        Popularity.instance.UpdatePopularity(popularityEffectAmount);
    }
}