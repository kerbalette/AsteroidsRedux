//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Project/InputSystem/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace MangledMonster.InputSystem
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Ingame"",
            ""id"": ""9a12e775-52d2-4dea-8b8a-bb8fe9d7aa39"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""73b2d892-1586-4ca2-9368-f1824e7a3c1b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Button"",
                    ""id"": ""f580dd16-3bd9-43f0-a24b-cf896774053d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""ef4113f3-d861-4e74-aab0-4f12f4629fe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Rotate"",
                    ""id"": ""58070f32-2c88-4099-af21-b0e6bbc8c811"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""47e9e9ed-181b-4baa-8e8b-5bba5107d1d1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""db88950f-e1e9-4926-a6f4-61e24825fa19"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cf4b9ec6-79a9-4e2c-a2ea-0c1bba280cf6"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""858eb99a-2a00-4156-af8e-51b725e648a5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b6d9bed-f70f-4963-878e-2a4933343963"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""155c51d1-42ed-4645-90e8-4accb9f5153b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3d9cb01-87fe-463b-b257-f3fd6d2d6276"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1da3f821-75df-4ef0-b183-59a73b45f45c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Ingame
            m_Ingame = asset.FindActionMap("Ingame", throwIfNotFound: true);
            m_Ingame_Movement = m_Ingame.FindAction("Movement", throwIfNotFound: true);
            m_Ingame_Thrust = m_Ingame.FindAction("Thrust", throwIfNotFound: true);
            m_Ingame_Fire = m_Ingame.FindAction("Fire", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Ingame
        private readonly InputActionMap m_Ingame;
        private IIngameActions m_IngameActionsCallbackInterface;
        private readonly InputAction m_Ingame_Movement;
        private readonly InputAction m_Ingame_Thrust;
        private readonly InputAction m_Ingame_Fire;
        public struct IngameActions
        {
            private @PlayerInputActions m_Wrapper;
            public IngameActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Ingame_Movement;
            public InputAction @Thrust => m_Wrapper.m_Ingame_Thrust;
            public InputAction @Fire => m_Wrapper.m_Ingame_Fire;
            public InputActionMap Get() { return m_Wrapper.m_Ingame; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
            public void SetCallbacks(IIngameActions instance)
            {
                if (m_Wrapper.m_IngameActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                    @Thrust.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnThrust;
                    @Thrust.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnThrust;
                    @Thrust.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnThrust;
                    @Fire.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnFire;
                }
                m_Wrapper.m_IngameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Thrust.started += instance.OnThrust;
                    @Thrust.performed += instance.OnThrust;
                    @Thrust.canceled += instance.OnThrust;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                }
            }
        }
        public IngameActions @Ingame => new IngameActions(this);
        public interface IIngameActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnThrust(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
        }
    }
}
