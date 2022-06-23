using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private int scoreAmount = 20;
    private void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
