using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
    }
}
