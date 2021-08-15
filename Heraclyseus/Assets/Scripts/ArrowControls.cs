// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Arrow Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ArrowControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ArrowControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Arrow Controls"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""3b30011e-8654-44cf-8363-cd771e014ab6"",
            ""actions"": [
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""19dc6dbe-22b7-474d-9d41-abdb61b49abf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookDir"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b94cb0a8-88ba-4204-a126-e236ca16b887"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6969c4bd-6c4e-4e5d-8798-fc9359533427"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5a87caf0-3edc-41f3-bfe6-aceb1860950b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""534c9833-1232-4a1a-8b72-4d5929b8e659"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""73248048-a2c3-4188-a6dd-be649fe94fd2"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa943b54-e4a1-4f49-bda8-2fe615bf4ff5"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d52e6e2c-9271-463d-8c3b-d0931d990257"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_MousePos = m_Combat.FindAction("MousePos", throwIfNotFound: true);
        m_Combat_LookDir = m_Combat.FindAction("LookDir", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_MousePos;
    private readonly InputAction m_Combat_LookDir;
    public struct CombatActions
    {
        private @ArrowControls m_Wrapper;
        public CombatActions(@ArrowControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePos => m_Wrapper.m_Combat_MousePos;
        public InputAction @LookDir => m_Wrapper.m_Combat_LookDir;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @MousePos.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMousePos;
                @LookDir.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnLookDir;
                @LookDir.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnLookDir;
                @LookDir.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnLookDir;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @LookDir.started += instance.OnLookDir;
                @LookDir.performed += instance.OnLookDir;
                @LookDir.canceled += instance.OnLookDir;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface ICombatActions
    {
        void OnMousePos(InputAction.CallbackContext context);
        void OnLookDir(InputAction.CallbackContext context);
    }
}
