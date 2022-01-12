using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolReturner : MonoBehaviour
{
    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        if(_objectPool != null)
            _objectPool.ReturnGameObject(this.gameObject);
    }
}
