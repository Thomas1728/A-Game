// GENERATED AUTOMATICALLY FROM 'Assets/GameInputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputController"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""e4de679e-fff9-4da7-890f-5edc74558ea9"",
            ""actions"": [
                {
                    ""name"": ""move_backward"",
                    ""type"": ""Button"",
                    ""id"": ""366a27b2-f842-4c47-98a3-600d980b4784"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""move_forward"",
                    ""type"": ""Button"",
                    ""id"": ""6ccbc25c-f772-47d9-b76a-f6780cdf7e41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""57e4498a-1e15-490e-b706-6eac18c4e37c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c5221c5-49b0-40b7-88c5-027899bfa032"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move_backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0c6cd2f-c32c-4d43-ab61-f7394e1259d0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move_forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf92c37c-86a3-426e-8cf1-1a1b61d0953a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_move_backward = m_player.FindAction("move_backward", throwIfNotFound: true);
        m_player_move_forward = m_player.FindAction("move_forward", throwIfNotFound: true);
        m_player_Jump = m_player.FindAction("Jump", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_move_backward;
    private readonly InputAction m_player_move_forward;
    private readonly InputAction m_player_Jump;
    public struct PlayerActions
    {
        private @GameInputController m_Wrapper;
        public PlayerActions(@GameInputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @move_backward => m_Wrapper.m_player_move_backward;
        public InputAction @move_forward => m_Wrapper.m_player_move_forward;
        public InputAction @Jump => m_Wrapper.m_player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @move_backward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_backward;
                @move_backward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_backward;
                @move_backward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_backward;
                @move_forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_forward;
                @move_forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_forward;
                @move_forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_forward;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move_backward.started += instance.OnMove_backward;
                @move_backward.performed += instance.OnMove_backward;
                @move_backward.canceled += instance.OnMove_backward;
                @move_forward.started += instance.OnMove_forward;
                @move_forward.performed += instance.OnMove_forward;
                @move_forward.canceled += instance.OnMove_forward;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove_backward(InputAction.CallbackContext context);
        void OnMove_forward(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
