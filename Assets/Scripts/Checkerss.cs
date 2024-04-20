using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerss : MonoBehaviour
{
    public static Checkerss instance;
    public GameObject tophat;
    public GameObject sunglasses;
    public GameObject shoes;
    public GameObject shoes2;
    public GameObject dumbbell;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        CheckBuy();
    }
    public void CheckBuy()
    {
        if (PlayerPrefs.HasKey("Buy1"))
        {
            tophat.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Buy2"))
        {
            sunglasses.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Buy3"))
        {
            shoes.SetActive(true);
            shoes2.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Buy4"))
        {
            dumbbell.SetActive(true);
        }
    }
}
