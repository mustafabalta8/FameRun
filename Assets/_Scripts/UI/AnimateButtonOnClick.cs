using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimateButtonOnClick : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(AnimateButton);
    }

    public void AnimateButton()
    {
        button.transform.DOScale(transform.localScale*1.2f, 0.3f).SetLoops(2, LoopType.Yoyo);
    }
   
}
