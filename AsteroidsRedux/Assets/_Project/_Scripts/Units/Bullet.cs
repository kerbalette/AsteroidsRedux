using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action<GameObject, int> onCollision;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private float _lifeSpan = 2f;
    
    private Rigidbody2D _rigidBody;
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _rigidBody.AddForce(this.transform.parent.up * _bulletSpeed, ForceMode2D.Impulse);
        this.transform.parent = null;
        StartCoroutine(DestroySelfAfterSeconds(_lifeSpan));
    }

    private IEnumerator DestroySelfAfterSeconds(float lifeSpan)
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
       onCollision?.Invoke(collision.gameObject, _damageAmount);
       Destroy(this.gameObject);
    }
}
