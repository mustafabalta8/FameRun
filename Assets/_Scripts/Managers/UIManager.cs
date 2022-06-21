using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject successUI;
    [SerializeField] private GameObject failUI;

    [SerializeField] private TextMeshProUGUI popularityText;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private TextMeshProUGUI successScreenTotalPopularity;
    [SerializeField] private TextMeshProUGUI successScreenTempPopularity;

    void Start()
    {
        Singelton();

        int levelNum = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = levelNum.ToString();
        popularityText.text = "";
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
    }
    public void OpenFailScreen()
    {
        inGameUI.SetActive(false);
        failUI.SetActive(true);
    }


}
