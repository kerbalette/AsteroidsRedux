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
        }

        private void FixedUpdate()
        {
                if (_playerInputActions.Ingame.Thrust.ReadValue<float>() > 0)
                {
                        _rigidbody2D.AddForce((transform.up * Time.fixedDeltaTime * 2f),ForceMode2D.Impulse);
                }
        }
}

