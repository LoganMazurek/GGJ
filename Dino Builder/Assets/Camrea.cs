using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camrea : MonoBehaviour
{
    public float Speed;
    private void Update()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * Speed, 0.0f);       
    }
}
