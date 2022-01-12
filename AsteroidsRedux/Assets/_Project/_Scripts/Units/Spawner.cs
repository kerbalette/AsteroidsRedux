
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
        [SerializeField] private float _timeToSpawn = 5f;
        [SerializeField] private float _timeSinceSpawn;
        [SerializeField] private GameObject _spawningPrefab;

        private ObjectPool _objectPool;

        private void Start()
        {
                _objectPool = FindObjectOfType<ObjectPool>();
        }

        private void Update()
        {
                _timeSinceSpawn += Time.deltaTime;
                if (_timeSinceSpawn >= _timeToSpawn)
                {
                        GameObject newPrefab = _objectPool.GetObject(_spawningPrefab);
                        newPrefab.transform.position = this.transform.position;
                        _timeSinceSpawn = 0f;
                }
        }
}
