using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{

    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject successUI;
    [SerializeField] private GameObject failUI;
    [SerializeField] private Transform successUIButton;
    [SerializeField] private Transform failUIButton;

    [SerializeField] private TextMeshProUGUI popularityText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private TextMeshProUGUI successScreenTotalPopularity;
    [SerializeField] private TextMeshProUGUI successScreenTempPopularity;

    [SerializeField] float fadeTime = 1;
    void Start()
    {
        int levelNum = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = levelNum.ToString();
        popularityText.text = "";
    }


    public void CloseStartPanel()
    {
        startUI.SetActive(false);
        inGameUI.SetActive(true);
        //GameManager.StartGame();
        GameManager.instance.UpdateGameState(GameStates.InGame);     
    }
    public void UpdatePopularity(int value)
    {
        popularityText.text = value.ToString();        
    }
    public void OpenSuccessScreen()
    {
        successScreenTotalPopularity.text = Popularity.TotalPopularity.ToString();
        successScreenTempPopularity.text = Popularity.instance.TempPopularity.ToString();
        inGameUI.SetActive(false);
        successUI.SetActive(true);
        FadeInPanel(successUI);
    }
    public void OpenFailScreen()
    {
        inGameUI.SetActive(false);
        failUI.SetActive(true);
        FadeInPanel(failUI);
    }


    public void FadeInPanel(GameObject screen) // open panel button
    {
        CanvasGroup canvasGroup = screen.GetComponent<CanvasGroup>();
        RectTransform rectTransform = screen.GetComponent<RectTransform>();
        canvasGroup.alpha = 0;
        rectTransform.transform.localPosition = new Vector3(0, -2500f, 0);
        rectTransform.DOAnchorPos(Vector2.zero, fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        //StartCoroutine(AnimateItems());
    }
    public void FadeInPanelSecond(GameObject screen) // open panel button
    {
        CanvasGroup canvasGroup = screen.GetComponent<CanvasGroup>();
        RectTransform rectTransform = screen.GetComponent<RectTransform>();
        canvasGroup.alpha = 0;
        rectTransform.transform.localPosition = new Vector3(0, -2500f, 0);
        rectTransform.DOAnchorPos(Vector2.zero, fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        //StartCoroutine(AnimateItems());
    }
    int selectedScreen;
    public void CloseWinPanel()
    {
        selectedScreen = 0;
        FadeOutPanel(successUI,successUIButton);
    }
    public void CloseFailPanel()
    {
        selectedScreen = 1;
        FadeOutPanel(failUI,failUIButton);
    }
   
    public void FadeOutPanel(GameObject screen, Transform button) // back button
    {

        CanvasGroup canvasGroup = screen.GetComponent<CanvasGroup>();
        RectTransform rectTransform = screen.GetComponent<RectTransform>();
        canvasGroup.alpha = 1;
        rectTransform.transform.localPosition = new Vector3(0, 0, 0);
        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(button.transform.DOScale(button.transform.localScale * 1.2f, 0.3f).SetLoops(2, LoopType.Yoyo))
            .Append(rectTransform.DOAnchorPos(new Vector2(0, -2500f), fadeTime, false).SetEase(Ease.InOutQuint))
            .OnComplete(OnFadeOutComplete)
            .Join(canvasGroup.DOFade(0.5f, fadeTime));

    }

    void OnFadeOutComplete()
    {
        if (selectedScreen == 0)
        {
            GameManager.PlayNextLevel();
        }
        else
        {
            GameManager.RestartGame();
        }

    }


}
