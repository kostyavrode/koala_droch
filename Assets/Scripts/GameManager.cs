using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    MENU=0,
    PLAYING=1,
    SHOP=2
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Rotator rotator;
    public Animator animator;
    public GameObject ballThrower;
    public Transform playerTransform;
    private Quaternion playerStartPosition;
    private float timer;
    private bool isMoneyBagGameStarted;
    private bool isRunGameStarted;
    private int money;
    private int koalaShots;
    public int moneyBagRuns;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("Level", 0);
            PlayerPrefs.Save();
        }
        UIManager.instance.ShowMoney(PlayerPrefs.GetInt("Money").ToString());
        Application.targetFrameRate = 60;
        playerStartPosition = playerTransform.rotation;
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartRunGame();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StopRunGame(false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartMoneyBagGame();
        }
        if (isMoneyBagGameStarted)
        {
            timer += Time.deltaTime;
            UIManager.instance.ShowTime((10 - System.Convert.ToInt32(timer)).ToString());
            if (timer>10)
            {
                StopMoneyBag();
                timer = 0;
                
            }
        }
        if (isRunGameStarted)
        {
            timer += Time.deltaTime;
            UIManager.instance.ShowTime((60 - System.Convert.ToInt32(timer)).ToString());
            if (koalaShots>=4)
            {
                StopRunGame(true);
                timer = 0;
            }
            if (timer > 60)
            {
                if (koalaShots<4)
                {
                    StopRunGame(false);
                    timer = 0;
                }

            }
        }
    }
    public void StopRunGame(bool isWin)
    {
        animator.SetBool("isRun", false);
        playerTransform.rotation = playerStartPosition;
        rotator.enabled = false;
        ballThrower.SetActive(false);
        isRunGameStarted = false;
        CameraRotator.instance.MoveCameraToStart();
        UIManager.instance.timeText.enabled = false;
        UIManager.instance.levelText.enabled = false;
        UIManager.instance.shotsText.enabled = false;
        if (isWin)
        {
            UIManager.instance.endRunGameScreenWin.SetActive(true);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.Save();
            moneyBagRuns += 1;
            UIManager.instance.ShowMoneyBagGames(moneyBagRuns.ToString());
        }
        else
        {
            UIManager.instance.endRunGameScreenLose.SetActive(true);
        }
    }
    public void StartRunGame()
    {
        animator.SetBool("isRun",true);
        StartCoroutine(WaitToStartMove());
        CameraRotator.instance.MoveCameraToRunGame();
        UIManager.instance.ShowLevel("Level " + PlayerPrefs.GetInt("Level"));
        isRunGameStarted = true;
        UIManager.instance.levelText.enabled = true;
        UIManager.instance.timeText.enabled = true;
        UIManager.instance.shotsText.enabled = true;
        UIManager.instance.ShowShots(("0/4"));
    }
    public void StartMoneyBagGame()
    {
        CameraRotator.instance.MoveCameraToGoldenBag();
        isMoneyBagGameStarted = true;
        UIManager.instance.timeText.enabled = true;
        moneyBagRuns -= 1;
        UIManager.instance.ShowMoneyBagGames(moneyBagRuns.ToString());
    }
    public void StopMoneyBag()
    {
        isMoneyBagGameStarted = false;
        UIManager.instance.timeText.enabled = false;
        UIManager.instance.endMoneyBagGameScreen.SetActive(true);
    }
    public void IncreasePlayerMoney()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        UIManager.instance.ShowMoney(PlayerPrefs.GetInt("Money").ToString());
    }
    public void ShotKoala()
    {
        koalaShots+=1;
        UIManager.instance.ShowShots((koalaShots.ToString() + "/4"));
    }
    public IEnumerator WaitToStartMove()
    {
        yield return new WaitForSeconds(3f);
        rotator.enabled = true;
        ballThrower.SetActive(true);
    }
}
