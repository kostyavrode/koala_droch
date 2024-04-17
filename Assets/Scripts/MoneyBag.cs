using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class MoneyBag : MonoBehaviour,IPointerClickHandler
{
    public ParticleSystem coinEffect;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("MONEYBAG");
        coinEffect.Play();
        GameManager.instance.IncreasePlayerMoney();
        transform.DOScale(9.2f, 0.1f).OnComplete(SetBagBack);
    }
    private void SetBagBack()
    {
        transform.DOScale(10, 0.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
