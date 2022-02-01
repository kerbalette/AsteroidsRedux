using System;
using System.Collections;
using System.Collections.Generic;
using MangledMonster.Systems;
using UnityEngine;
using UnityEngine.Rendering;

public class PooledMonoBehaviour : MonoBehaviour
{
    [SerializeField] private int _initialPoolSize = 5;

    public event Action<PooledMonoBehaviour> OnReturnToPool;
    
    public int InitialPoolSize { get { return _initialPoolSize; } }

    public T Get<T>(bool enable = true) where T : PooledMonoBehaviour
    {
        var pool = Pool.GetPool(this);
        var pooledObject = pool.Get<T>();
        
        if (enable)
        {
            pooledObject.gameObject.SetActive(true);
        }
        return pooledObject;
    }

    public T Get<T>(Vector3 position, Quaternion rotation) where T : PooledMonoBehaviour
    {
        var pooledObject = Get<T>();

        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        Bullet obj = pooledObject as Bullet;
        obj.Rotation = rotation;
        
        return pooledObject;
    }


    private void OnDisable()
    {
        if (OnReturnToPool != null)
            OnReturnToPool(this);
    }
}
