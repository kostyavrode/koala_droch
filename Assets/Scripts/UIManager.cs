using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text timeText;
    public TMP_Text levelText;
    public TMP_Text shotsText;
    public TMP_Text moneyText;
    public TMP_Text moneyBagGamesText;
    public GameObject endMoneyBagGameScreen;
    public GameObject endRunGameScreenWin;
    public GameObject endRunGameScreenLose;
    public GameObject startMenu;
    public AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }
    public void ShowMoney(string data)
    {
        moneyText.text = data;
    }
    public void ShowTime(string data)
    {
        timeText.text = data;
    }
    public void ShowLevel(string data)
    {
        levelText.text = data;
    }
    public void ShowShots(string data)
    {
        shotsText.text = data;
    }
    public void ShowMoneyBagGames(string data)
    {
        moneyBagGamesText.text = data;
    }
    public void StartRunGame()
    {
        GameManager.instance.StartRunGame();
    }
    public void StartMoneyBagGame()
    {
        if (GameManager.instance.moneyBagRuns>=1)
        {
            GameManager.instance.StartMoneyBagGame();
            startMenu.SetActive(false);
        }
    }
    public void EndGameButton()
    {
        CameraRotator.instance.MoveCameraToStart();
        endMoneyBagGameScreen.SetActive(false);
    }
    public void EndRunGameButton()
    {
        CameraRotator.instance.MoveCameraToStart();
        endRunGameScreenLose.SetActive(false);
        endRunGameScreenWin.SetActive(false);
    }
    public void OpenSettings()
    {
        Time.timeScale = 0;
    }
    public void CloseSettings()
    {
        Time.timeScale = 1;
    }
    public void BackToMenuButton()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void SoundOn()
    {
        PlayerPrefs.SetString("Sound", "true");
        PlayerPrefs.Save();
        audioSource.Play();
    }
    public void SoundOff()
    {
        PlayerPrefs.SetString("Sound", "false");
        PlayerPrefs.Save();
        audioSource.Pause();
    }
}
