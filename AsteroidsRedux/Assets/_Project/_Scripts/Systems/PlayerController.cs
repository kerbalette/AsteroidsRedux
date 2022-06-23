using System;
using System.Collections;
using System.Collections.Generic;
using MangledMonster.InputSystem;
using MangledMonster.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private float turnSpeed = 400f;
        [SerializeField] private float thrustSpeed = 2f;
        [SerializeField] private GameObject thrustSprite;
 //       [SerializeField] private Bullet _bullet;
        [SerializeField] private GameObject bulletSpawn;
        [SerializeField] private float fireRate = 5f;
        [SerializeField] private float bulletSpeed = 10f;

        private PlayerInputActions _playerInputActions;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _screenBounds;
        private Coroutine _fireCoroutine;
        private WaitForSeconds _rapidFireWait;
        private PooledBulletManager _pooledBulletManager;

        private void Awake()
        {
                _playerInputActions = new PlayerInputActions();
                _rigidbody2D = GetComponent<Rigidbody2D>();
                
                _playerInputActions.Ingame.Thrust.started += OnThrustStarted;
                _playerInputActions.Ingame.Thrust.canceled += OnThrustCancelled;

                _playerInputActions.Ingame.Fire.started += _ => StartFiring();
                _playerInputActions.Ingame.Fire.canceled += _ => StopFiring();

                _pooledBulletManager = bulletSpawn.GetComponent<PooledBulletManager>();
                _rapidFireWait = new WaitForSeconds(1 / fireRate);
        }

        private void OnEnable()
        {
                _playerInputActions.Enable();
        }

        private void OnDisable()
        {
                _playerInputActions.Disable();
        }

        private void Start()
        {
                _screenBounds =
                        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                                Camera.main.transform.position.z));
        }

        private void StartFiring()
        {
                _fireCoroutine = StartCoroutine(RapidFire());
        }

        private void StopFiring()
        {
                if (_fireCoroutine != null)
                        StopCoroutine(_fireCoroutine);
        }

        private void Shoot()
        {
                _pooledBulletManager.FireBullet(bulletSpeed);

                //var bullet = _bullet.Get<Bullet>(_bulletSpawn.position, _bulletSpawn.rotation);
                //bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 20f,ForceMode2D.Impulse);


                /*var bullet = Instantiate(_bullet, _bulletSpawn.position, Quaternion.identity);
                bullet.transform.parent = transform;*/

                // bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 20f,ForceMode2D.Impulse);
        }

        private IEnumerator RapidFire()
        {
                while (true)
                {
                        Shoot();
                        yield return _rapidFireWait;
                }
        }
        
        private void OnThrustCancelled(InputAction.CallbackContext obj)
        {
                thrustSprite.SetActive(false);
        }

        private void OnThrustStarted(InputAction.CallbackContext obj)
        {
                thrustSprite.SetActive(true);
        }

        private void Update()
        {
                transform.Rotate(0f,0f,(_playerInputActions.Ingame.Movement.ReadValue<float>()  * turnSpeed * Time.deltaTime )) ;

                CheckBoundaries();
        }

        private void CheckBoundaries()
        {
                if (transform.position.x > _screenBounds.x)
                        transform.position = new Vector3(_screenBounds.x * -1, transform.position.y, transform.position.z);


                if (transform.position.x < _screenBounds.x * -1)
                        transform.position = new Vector3(_screenBounds.x, transform.position.y, transform.position.z);


                if (transform.position.y > _screenBounds.y)
                        transform.position = new Vector3(transform.position.x, _screenBounds.y * -1,
                                transform.position.z);

                if (transform.position.y < _screenBounds.y * -1)
                        transform.position = new Vector3(transform.position.x, _screenBounds.y, transform.position.z);
        }

        private void FixedUpdate()
        {
                if (_playerInputActions.Ingame.Thrust.ReadValue<float>() > 0)
                {
                        _rigidbody2D.AddForce((transform.up * Time.fixedDeltaTime * thrustSpeed),ForceMode2D.Impulse);
                }
        }
}

