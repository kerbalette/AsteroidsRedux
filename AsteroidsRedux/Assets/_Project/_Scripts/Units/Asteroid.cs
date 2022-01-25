using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private int _scoreAmount = 20;
    private void Update()
    {
        transform.Rotate(0,0,_rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        Bullet.onCollision += BulletOnonCollision;
    }

    private void OnDisable()
    {
        Bullet.onCollision -= BulletOnonCollision;
    }



    private void BulletOnonCollision(GameObject arg1, int arg2)
    {
        if(arg1 == this.gameObject)
            Debug.Log("GameObject: " + arg1.name + ", " + arg2.ToString());
    }
}
