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
}
