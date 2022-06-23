using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
        [SerializeField] private float lifeSpan = 2f;

        //public UnityEvent<GameObject> OnLifespanExpired = new UnityEvent<GameObject>();
        public event Action<GameObject> OnLifespanExpired; 
        
        private void OnEnable()
        {
                StartCoroutine(DestroySelfAfterSeconds(lifeSpan));
        }

        private IEnumerator DestroySelfAfterSeconds(float lifeSpan)
        {
                yield return new WaitForSeconds(lifeSpan);
                OnLifespanExpired?.Invoke(gameObject);
        }
}
