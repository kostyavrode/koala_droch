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
    private Vector3 playerStartPosition;
    private float timer;
    private bool isMoneyBagGameStarted;
    private int money;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        playerStartPosition = playerTransform.position;
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
            StopRunGame();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartMoneyBagGame();
        }
        if (isMoneyBagGameStarted)
        {
            timer += Time.deltaTime;
            UIManager.instance.ShowTimeOrLevel((10 - System.Convert.ToInt32(timer)).ToString());
            if (timer>10)
            {
                StopMoneyBag();
                timer = 0;
                
            }
        }
    }
    public void StopRunGame()
    {
        animator.SetBool("isRun", false);
        playerTransform.position = playerStartPosition;
        rotator.enabled = false;
        ballThrower.SetActive(false);
        CameraRotator.instance.MoveCameraToStart();
        UIManager.instance.time_levelText.enabled = false;
    }
    public void StartRunGame()
    {
        animator.SetBool("isRun",true);
        StartCoroutine(WaitToStartMove());
        CameraRotator.instance.MoveCameraToRunGame();
        UIManager.instance.ShowTimeOrLevel("Level " + PlayerPrefs.GetInt("Level"));
        UIManager.instance.time_levelText.enabled = true;
    }
    public void StartMoneyBagGame()
    {
        CameraRotator.instance.MoveCameraToGoldenBag();
        isMoneyBagGameStarted = true;
        UIManager.instance.time_levelText.enabled = true;
    }
    public void StopMoneyBag()
    {
        isMoneyBagGameStarted = false;
        UIManager.instance.time_levelText.enabled = false;
        UIManager.instance.endMoneyBagGameScreen.SetActive(true);
    }
    public void IncreasePlayerMoney()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
    }
    public IEnumerator WaitToStartMove()
    {
        yield return new WaitForSeconds(2f);
        rotator.enabled = true;
        ballThrower.SetActive(true);
    }
}
