using System;
using System.Collections;
using System.Collections.Generic;
using MangledMonster.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private float _turnSpeed = 400f;
        [SerializeField] private GameObject _thrustSprite;
        
        
        private PlayerInputActions _playerInputActions;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _screenBounds;

        private void Awake()
        {
                _playerInputActions = new PlayerInputActions();
                _rigidbody2D = GetComponent<Rigidbody2D>();
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
                _playerInputActions.Ingame.Thrust.started += OnThrustStarted;
                _playerInputActions.Ingame.Thrust.canceled += OnThrustCancelled;

                _playerInputActions.Ingame.Fire.performed += OnFirePerformed;

                _screenBounds =
                        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                                Camera.main.transform.position.z));
                Debug.Log(_screenBounds);
        }

        private void OnFirePerformed(InputAction.CallbackContext obj)
        {
        }

        private void OnThrustCancelled(InputAction.CallbackContext obj)
        {
                _thrustSprite.SetActive(false);
        }

        private void OnThrustStarted(InputAction.CallbackContext obj)
        {
                _thrustSprite.SetActive(true);
        }

        private void Update()
        {
                transform.Rotate(0f,0f,(_playerInputActions.Ingame.Movement.ReadValue<float>()  * _turnSpeed * Time.deltaTime )) ;

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
                        _rigidbody2D.AddForce((transform.up * Time.fixedDeltaTime * 2f),ForceMode2D.Impulse);
                }
        }
}

