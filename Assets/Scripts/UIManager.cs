using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text time_levelText;
    public GameObject endMoneyBagGameScreen;
    private void Awake()
    {
        instance = this;
    }
    public void ShowTimeOrLevel(string data)
    {
        time_levelText.text = data;
    }
    public void EndGameButton()
    {
        CameraRotator.instance.MoveCameraToStart();
        endMoneyBagGameScreen.SetActive(false);
    }
}
