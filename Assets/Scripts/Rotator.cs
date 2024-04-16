using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    private void Update()
    {
        transform.Rotate(rotateX, rotateY, rotateZ);
    }
}
