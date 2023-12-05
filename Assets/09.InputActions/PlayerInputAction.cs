//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/09.InputActions/PlayerInputAction.inputactions
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

public partial class @PlayerInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fdb0c0ff-5237-4360-8787-21e6dd4934ac"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""660c97aa-dcb5-491f-b3b9-283abd431633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""814f954b-41a0-496a-b8db-472bdc1d26ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillUI"",
                    ""type"": ""Button"",
                    ""id"": ""86827feb-d7de-4cd1-8f3a-6d7f53280b1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""fe2f5cfe-5192-4dd5-b34e-3580a826e12b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quest"",
                    ""type"": ""Button"",
                    ""id"": ""ae8a7be6-a2c6-4a33-a287-fc77f55fb413"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""15f124d0-4c1d-4004-a6d4-74c1681b5bfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""a5eef219-0fa3-4bcd-a75b-2d6237916f5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot1"",
                    ""type"": ""Button"",
                    ""id"": ""bba69be8-f5b5-42af-bb32-78e5650fd73e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot2"",
                    ""type"": ""Button"",
                    ""id"": ""5f0f755a-63c7-45a9-8ad2-518333f471de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot3"",
                    ""type"": ""Button"",
                    ""id"": ""f7fb5550-c019-43af-9f6a-a39fb3d89263"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot4"",
                    ""type"": ""Button"",
                    ""id"": ""c25eeb27-9fa7-4cdf-9816-1148a0b36697"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuickSlot5"",
                    ""type"": ""Button"",
                    ""id"": ""57f61f5c-3b64-4cdf-8564-9f8c217a663c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""e403dbba-c9e5-4f09-a9ce-d5514a841992"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseScrollY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8f64c1db-a2ff-4c84-9005-3e7d2f4ec716"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseScrollClick"",
                    ""type"": ""Value"",
                    ""id"": ""13de8f3c-6458-4b09-a83d-f8fbb6a1ace0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6fa053a4-f486-41fc-bf24-f5d11f9aa137"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00bdec11-6c3d-42be-b9d4-dc64b9b443a3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""348b8d64-5d8e-49ff-a1d8-46d04fa16463"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa8ee6fb-c7b3-4231-8da4-5ec435dd1336"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6efa130b-e70a-418a-a0f8-c9969bc5fbd5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea447a61-fa46-4877-8208-486a7314da5e"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42e31b7e-bd92-4723-b993-09dcd27c3151"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00fdb953-f788-4895-9f7e-1b8d922c7ee5"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acc7a296-458e-4832-883d-a78f88a77198"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afbdd30e-8237-4fa9-a976-b25883bf0901"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""389e4549-d758-4e2e-bbbe-316d20b8a6b9"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fb8ea8f-acde-4d0e-9710-6267ebcb9cd9"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlot5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb99ab54-5b98-42af-b334-820ec3f8169f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cca89003-0705-4743-996b-2a481bbc3c0a"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScrollY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec26143d-57d2-4977-942c-0cc845c1123a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScrollClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_SkillUI = m_Player.FindAction("SkillUI", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_Quest = m_Player.FindAction("Quest", throwIfNotFound: true);
        m_Player_Map = m_Player.FindAction("Map", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_QuickSlot1 = m_Player.FindAction("QuickSlot1", throwIfNotFound: true);
        m_Player_QuickSlot2 = m_Player.FindAction("QuickSlot2", throwIfNotFound: true);
        m_Player_QuickSlot3 = m_Player.FindAction("QuickSlot3", throwIfNotFound: true);
        m_Player_QuickSlot4 = m_Player.FindAction("QuickSlot4", throwIfNotFound: true);
        m_Player_QuickSlot5 = m_Player.FindAction("QuickSlot5", throwIfNotFound: true);
        m_Player_Escape = m_Player.FindAction("Escape", throwIfNotFound: true);
        m_Player_MouseScrollY = m_Player.FindAction("MouseScrollY", throwIfNotFound: true);
        m_Player_MouseScrollClick = m_Player.FindAction("MouseScrollClick", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_SkillUI;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_Quest;
    private readonly InputAction m_Player_Map;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_QuickSlot1;
    private readonly InputAction m_Player_QuickSlot2;
    private readonly InputAction m_Player_QuickSlot3;
    private readonly InputAction m_Player_QuickSlot4;
    private readonly InputAction m_Player_QuickSlot5;
    private readonly InputAction m_Player_Escape;
    private readonly InputAction m_Player_MouseScrollY;
    private readonly InputAction m_Player_MouseScrollClick;
    public struct PlayerActions
    {
        private @PlayerInputAction m_Wrapper;
        public PlayerActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @SkillUI => m_Wrapper.m_Player_SkillUI;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @Quest => m_Wrapper.m_Player_Quest;
        public InputAction @Map => m_Wrapper.m_Player_Map;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @QuickSlot1 => m_Wrapper.m_Player_QuickSlot1;
        public InputAction @QuickSlot2 => m_Wrapper.m_Player_QuickSlot2;
        public InputAction @QuickSlot3 => m_Wrapper.m_Player_QuickSlot3;
        public InputAction @QuickSlot4 => m_Wrapper.m_Player_QuickSlot4;
        public InputAction @QuickSlot5 => m_Wrapper.m_Player_QuickSlot5;
        public InputAction @Escape => m_Wrapper.m_Player_Escape;
        public InputAction @MouseScrollY => m_Wrapper.m_Player_MouseScrollY;
        public InputAction @MouseScrollClick => m_Wrapper.m_Player_MouseScrollClick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @SkillUI.started += instance.OnSkillUI;
            @SkillUI.performed += instance.OnSkillUI;
            @SkillUI.canceled += instance.OnSkillUI;
            @Inventory.started += instance.OnInventory;
            @Inventory.performed += instance.OnInventory;
            @Inventory.canceled += instance.OnInventory;
            @Quest.started += instance.OnQuest;
            @Quest.performed += instance.OnQuest;
            @Quest.canceled += instance.OnQuest;
            @Map.started += instance.OnMap;
            @Map.performed += instance.OnMap;
            @Map.canceled += instance.OnMap;
            @Dodge.started += instance.OnDodge;
            @Dodge.performed += instance.OnDodge;
            @Dodge.canceled += instance.OnDodge;
            @QuickSlot1.started += instance.OnQuickSlot1;
            @QuickSlot1.performed += instance.OnQuickSlot1;
            @QuickSlot1.canceled += instance.OnQuickSlot1;
            @QuickSlot2.started += instance.OnQuickSlot2;
            @QuickSlot2.performed += instance.OnQuickSlot2;
            @QuickSlot2.canceled += instance.OnQuickSlot2;
            @QuickSlot3.started += instance.OnQuickSlot3;
            @QuickSlot3.performed += instance.OnQuickSlot3;
            @QuickSlot3.canceled += instance.OnQuickSlot3;
            @QuickSlot4.started += instance.OnQuickSlot4;
            @QuickSlot4.performed += instance.OnQuickSlot4;
            @QuickSlot4.canceled += instance.OnQuickSlot4;
            @QuickSlot5.started += instance.OnQuickSlot5;
            @QuickSlot5.performed += instance.OnQuickSlot5;
            @QuickSlot5.canceled += instance.OnQuickSlot5;
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
            @MouseScrollY.started += instance.OnMouseScrollY;
            @MouseScrollY.performed += instance.OnMouseScrollY;
            @MouseScrollY.canceled += instance.OnMouseScrollY;
            @MouseScrollClick.started += instance.OnMouseScrollClick;
            @MouseScrollClick.performed += instance.OnMouseScrollClick;
            @MouseScrollClick.canceled += instance.OnMouseScrollClick;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @SkillUI.started -= instance.OnSkillUI;
            @SkillUI.performed -= instance.OnSkillUI;
            @SkillUI.canceled -= instance.OnSkillUI;
            @Inventory.started -= instance.OnInventory;
            @Inventory.performed -= instance.OnInventory;
            @Inventory.canceled -= instance.OnInventory;
            @Quest.started -= instance.OnQuest;
            @Quest.performed -= instance.OnQuest;
            @Quest.canceled -= instance.OnQuest;
            @Map.started -= instance.OnMap;
            @Map.performed -= instance.OnMap;
            @Map.canceled -= instance.OnMap;
            @Dodge.started -= instance.OnDodge;
            @Dodge.performed -= instance.OnDodge;
            @Dodge.canceled -= instance.OnDodge;
            @QuickSlot1.started -= instance.OnQuickSlot1;
            @QuickSlot1.performed -= instance.OnQuickSlot1;
            @QuickSlot1.canceled -= instance.OnQuickSlot1;
            @QuickSlot2.started -= instance.OnQuickSlot2;
            @QuickSlot2.performed -= instance.OnQuickSlot2;
            @QuickSlot2.canceled -= instance.OnQuickSlot2;
            @QuickSlot3.started -= instance.OnQuickSlot3;
            @QuickSlot3.performed -= instance.OnQuickSlot3;
            @QuickSlot3.canceled -= instance.OnQuickSlot3;
            @QuickSlot4.started -= instance.OnQuickSlot4;
            @QuickSlot4.performed -= instance.OnQuickSlot4;
            @QuickSlot4.canceled -= instance.OnQuickSlot4;
            @QuickSlot5.started -= instance.OnQuickSlot5;
            @QuickSlot5.performed -= instance.OnQuickSlot5;
            @QuickSlot5.canceled -= instance.OnQuickSlot5;
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
            @MouseScrollY.started -= instance.OnMouseScrollY;
            @MouseScrollY.performed -= instance.OnMouseScrollY;
            @MouseScrollY.canceled -= instance.OnMouseScrollY;
            @MouseScrollClick.started -= instance.OnMouseScrollClick;
            @MouseScrollClick.performed -= instance.OnMouseScrollClick;
            @MouseScrollClick.canceled -= instance.OnMouseScrollClick;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSkillUI(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnQuest(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnQuickSlot1(InputAction.CallbackContext context);
        void OnQuickSlot2(InputAction.CallbackContext context);
        void OnQuickSlot3(InputAction.CallbackContext context);
        void OnQuickSlot4(InputAction.CallbackContext context);
        void OnQuickSlot5(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnMouseScrollY(InputAction.CallbackContext context);
        void OnMouseScrollClick(InputAction.CallbackContext context);
    }
}
