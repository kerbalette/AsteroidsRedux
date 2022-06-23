using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledBulletManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int defaultPoolSize = 15;
    [SerializeField] private int maxPoolSize = 50;
    
    public ObjectPool<GameObject> BulletPool;

    private void RetrieveFromPool(GameObject bullet)
    {
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.OnLifespanExpired += OnLifespanExpired;
        
        bullet.SetActive(true);
        bullet.transform.position = transform.position;
    }

    private void OnLifespanExpired(GameObject bullet) => BulletPool.Release(bullet);
    
    private void ReturnToPool(GameObject bullet)
    {
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.OnLifespanExpired -= OnLifespanExpired;
        bullet.SetActive(false);
    }

    private void DestroyPooledObject(GameObject bullet) => Destroy(bullet);
    
    private GameObject CreateBullet()
    {
        return Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        BulletPool = new ObjectPool<GameObject>(CreateBullet, RetrieveFromPool, ReturnToPool, DestroyPooledObject,
            true, defaultPoolSize, maxPoolSize);
    }

    public void FireBullet(float bulletSpeed)
    {
        var bullet = BulletPool.Get();
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed,ForceMode2D.Impulse);
    }
}
