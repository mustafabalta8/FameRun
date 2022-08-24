using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private static GameStates gameState;
    public static GameStates GameState { get => gameState; set => gameState = value; }
    private void Awake()
    {
        GameState = GameStates.Menu;
        Singelton();
    }

    public static void StartGame()
    {
        gameState = GameStates.InGame;
        PlayerManager.instance.UpdateAnimationState(AnimationState.Walking);
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
    public void HandleFailing()
    {
        gameState = GameStates.Fail;
        PlayerManager.instance.UpdateAnimationState(AnimationState.Failing);
        UIManager.instance.OpenFailScreen();
    }
    public void HandeWinning()
    {
        CameraManager.instance.UpdateCameraSettingsToTheFinalStage();
        Popularity.TotalPopularity += Popularity.instance.TempPopularity;
        StartCoroutine(CallSuccessUIWithDelay());
    }
    IEnumerator CallSuccessUIWithDelay()
    {
        yield return new WaitForSeconds(3f);
        UIManager.instance.OpenSuccessScreen();
    }
    public static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void PlayNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex > 9) { SceneManager.LoadScene(0); }
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }

}

public enum GameStates
{
    Menu,
    InGame,
    Final,
    Success,
    Fail
}
