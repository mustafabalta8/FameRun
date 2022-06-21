using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopularityBar : MonoBehaviour
{
    // Bar Variables
    [SerializeField] private float maxPopularity;
     public static float currentPopularity;

    // Bar fill color variables
    [SerializeField] private Image bar;
    [SerializeField] private Gradient gradient;

    //  Bar Text Variables
    [SerializeField] private TMP_Text barText;
    [SerializeField] private List<Color> textColors;

    public static PopularityBar instance;

    [SerializeField] private float firstStateInterval = 0.25f;
    [SerializeField] private float secondStateInterval = 0.5f;
    [SerializeField] private float thirdStateInterval = 0.75f;
    private void Start()
    {
        barText.color = textColors[0];
        Singelton();
        currentPopularity = 0;
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



    public void UpdateBar(float currentPopularity)
    {
        if (currentPopularity < 0) currentPopularity = 0;
        if (currentPopularity > maxPopularity) currentPopularity = maxPopularity;

        var popularityAmount = currentPopularity / maxPopularity;

        PopUpText(popularityAmount);

        //bar.fillAmount = popularityAmount;
        bar.color = gradient.Evaluate(popularityAmount);
    }

    private void PopUpText(float loveAmount)
    {
        //print("loveAmount" + loveAmount);
        if (loveAmount <= firstStateInterval)
        {
            barText.text = "DESPERATE";
            bar.fillAmount = loveAmount / firstStateInterval;
            barText.color = textColors[0];
            PlayerManager.instance.UpdateCharacterState(CharacterState.Desperate);

        }
        else if (firstStateInterval < loveAmount && loveAmount <= secondStateInterval)
        {
            barText.text = "MODEST";
            bar.fillAmount = (loveAmount - firstStateInterval) / (secondStateInterval-firstStateInterval);
            barText.color = textColors[1];
            PlayerManager.instance.UpdateCharacterState(CharacterState.Modest);
        }
        else if (secondStateInterval < loveAmount && loveAmount <= thirdStateInterval)
        {
            barText.text = "FAMOUS";
            bar.fillAmount = (loveAmount - secondStateInterval) / (thirdStateInterval-secondStateInterval);
            barText.color = textColors[2];
            PlayerManager.instance.UpdateCharacterState(CharacterState.Famous);
        }
        else
        {
            barText.text = "SUPERSTAR";
            bar.fillAmount = (loveAmount - thirdStateInterval) / (1f-thirdStateInterval);
            barText.color = textColors[3];
            PlayerManager.instance.UpdateCharacterState(CharacterState.Superstar);
        }

    }
}
