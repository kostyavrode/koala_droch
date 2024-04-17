using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraRotator : MonoBehaviour
{
    public static CameraRotator instance;
    public Transform runGameCameraPosition;
    public Transform startCameraPosition;
    public Transform goldenBagCameraPosition;
    private void Awake()
    {
        instance = this;
        MoveCameraToStart();
    }
    public void MoveCameraToRunGame()
    {
        transform.DOLocalMove(runGameCameraPosition.position, 1);
        transform.DOLocalRotateQuaternion(runGameCameraPosition.rotation, 0.8f);
    }
    public void MoveCameraToStart()
    {
        transform.DOLocalMove(startCameraPosition.position, 1);
        transform.DOLocalRotateQuaternion(startCameraPosition.rotation, 0.8f);
    }
    public void MoveCameraToGoldenBag()
    {
        transform.DOLocalMove(goldenBagCameraPosition.position, 1);
        transform.DOLocalRotateQuaternion(goldenBagCameraPosition.rotation, 0.8f);
    }
}
