using System;
using UnityEngine;

namespace _Project._Scripts.Units
{
    public class AsteroidsGenericPooled : MonoBehaviour
    {
        public float moveSpeed = 30f;
        private float lifeTime;
        private float maxLifetime = 5f;

        private void OnEnable()
        {
            lifeTime = 0f;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            lifeTime += Time.deltaTime;
            if (lifeTime > maxLifetime)
                AsteroidPool.Instance.ReturnToPool(this);
        }
    }
}