using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PooledMonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _lifeSpan = 2f;

    public Quaternion Rotation
    {
        get { return _rotation; }
        set { _rotation = value; }
    }
    
    private Rigidbody2D _rigidBody;
    private Quaternion _rotation;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
       // OnReturnToPool += ReturnToPool;
    }

    private void Start()
    {
        //_rigidBody.AddForce(this.transform.parent.up * _bulletSpeed, ForceMode2D.Impulse);
        //this.transform.parent = null;
        //StartCoroutine(DestroySelfAfterSeconds(_lifeSpan));
    }

    private void OnEnable()
    {
        Debug.Log(this.name);
        this.transform.rotation = _rotation;
        //_rigidBody.AddForce(this.transform.up * _bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroySelfAfterSeconds(_lifeSpan));
    }

    private IEnumerator DestroySelfAfterSeconds(float lifeSpan)
    {
        yield return new WaitForSeconds(lifeSpan);
        ReturnToPool(this);
    }

    private void ReturnToPool(PooledMonoBehaviour obj)
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReturnToPool(this);
    }
    
    /*public static event Action<GameObject, int> onCollision;
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
        Destroy(this.gameObject);
    }*/
}
