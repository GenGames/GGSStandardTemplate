// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input&EditorControllers/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player2D"",
            ""id"": ""ee7f7373-e712-40ea-b09d-e7a640718de4"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""10af964a-cc52-4cd0-af67-f04dcc458900"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""670a1ce1-48c8-43ef-9b1f-6e78b8d15df3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player3DFP"",
            ""id"": ""a82448cb-a2e9-4627-80c4-a7baa6ea9cef"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0d2bb9a3-d17b-4926-a5d5-11639f7f1351"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6fbf7578-5b4e-47cc-8ebe-105c465184e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""ab04de9b-0cf8-4d81-b2ba-75e12a12d575"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASDkeys"",
                    ""id"": ""72409269-7851-4198-8b6a-ff235ce03887"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bac2d92e-8fb1-4354-ae09-020968fe7b46"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06f8cee2-c3a8-4ea8-9400-22be194ce666"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""644cf50a-dfdc-4633-8b58-74942e21a25e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d2274be8-e77d-4629-b453-5e68a2f58bda"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""7a3b8c69-4194-4dc0-a4ef-94d5b7f22b83"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8183e8b1-0660-4f87-ab38-f4109c155892"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""625c1e3c-7208-4d5c-88fd-21291db29ba2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f26e071-0925-4fb2-8a5f-74bc765afd19"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a3dab83e-c1a5-46c5-b521-2533e081cf87"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a0be0bed-5b49-4779-9220-e537fe1760b2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""428518dc-b7fa-4946-a4fe-8b2c2118021f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerThreeDThirdPerson"",
            ""id"": ""b6991fd2-7421-474a-9f6d-d576d43198b8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4a6068c6-4af5-41a6-8030-a02d5faa9bef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASDkeys"",
                    ""id"": ""9655ed37-d8a7-434e-bd5b-5e78b2b78d27"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""22ac8b4a-9caf-41cb-89cc-46872a1506ba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d1fb9fff-22ca-4fd0-a78d-665da035e678"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0d79d3d-0a2d-41e1-903a-881640ec3f62"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3564fe0f-9e7f-4e23-b1e4-324287664bb8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""90ca7958-387e-44a4-83f2-6d843ddd2eb0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2f8297d1-e110-40dd-a483-f326805644f5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""52fa4e95-6c42-46c9-a104-8044a7275778"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6802d017-22d2-409d-a321-8059f2cd2918"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""79843850-8a55-41cd-b808-d5db24797282"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""RTSCamera"",
            ""id"": ""75b1282a-f1dd-4176-a1ed-4066fee5735f"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""336e2dbc-f680-4683-a517-acf75bf8d68d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5818d257-4859-4039-a9dd-ba8d1b34234e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FreeCamera"",
            ""id"": ""3145741c-8743-4bce-ba88-c4195b3d6ffe"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""b1df7cde-7319-438a-bb1a-38a37b108d04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""15229747-1ce6-4471-b69e-5585d16250bd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player2D
        m_Player2D = asset.FindActionMap("Player2D", throwIfNotFound: true);
        m_Player2D_Newaction = m_Player2D.FindAction("New action", throwIfNotFound: true);
        // Player3DFP
        m_Player3DFP = asset.FindActionMap("Player3DFP", throwIfNotFound: true);
        m_Player3DFP_Movement = m_Player3DFP.FindAction("Movement", throwIfNotFound: true);
        m_Player3DFP_Jump = m_Player3DFP.FindAction("Jump", throwIfNotFound: true);
        m_Player3DFP_Rotation = m_Player3DFP.FindAction("Rotation", throwIfNotFound: true);
        // PlayerThreeDThirdPerson
        m_PlayerThreeDThirdPerson = asset.FindActionMap("PlayerThreeDThirdPerson", throwIfNotFound: true);
        m_PlayerThreeDThirdPerson_Movement = m_PlayerThreeDThirdPerson.FindAction("Movement", throwIfNotFound: true);
        // RTSCamera
        m_RTSCamera = asset.FindActionMap("RTSCamera", throwIfNotFound: true);
        m_RTSCamera_Newaction = m_RTSCamera.FindAction("New action", throwIfNotFound: true);
        // FreeCamera
        m_FreeCamera = asset.FindActionMap("FreeCamera", throwIfNotFound: true);
        m_FreeCamera_Newaction = m_FreeCamera.FindAction("New action", throwIfNotFound: true);
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

    // Player2D
    private readonly InputActionMap m_Player2D;
    private IPlayer2DActions m_Player2DActionsCallbackInterface;
    private readonly InputAction m_Player2D_Newaction;
    public struct Player2DActions
    {
        private @InputMaster m_Wrapper;
        public Player2DActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Player2D_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Player2D; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2DActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2DActions instance)
        {
            if (m_Wrapper.m_Player2DActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_Player2DActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_Player2DActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_Player2DActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_Player2DActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public Player2DActions @Player2D => new Player2DActions(this);

    // Player3DFP
    private readonly InputActionMap m_Player3DFP;
    private IPlayer3DFPActions m_Player3DFPActionsCallbackInterface;
    private readonly InputAction m_Player3DFP_Movement;
    private readonly InputAction m_Player3DFP_Jump;
    private readonly InputAction m_Player3DFP_Rotation;
    public struct Player3DFPActions
    {
        private @InputMaster m_Wrapper;
        public Player3DFPActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player3DFP_Movement;
        public InputAction @Jump => m_Wrapper.m_Player3DFP_Jump;
        public InputAction @Rotation => m_Wrapper.m_Player3DFP_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_Player3DFP; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player3DFPActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer3DFPActions instance)
        {
            if (m_Wrapper.m_Player3DFPActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnJump;
                @Rotation.started -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_Player3DFPActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_Player3DFPActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public Player3DFPActions @Player3DFP => new Player3DFPActions(this);

    // PlayerThreeDThirdPerson
    private readonly InputActionMap m_PlayerThreeDThirdPerson;
    private IPlayerThreeDThirdPersonActions m_PlayerThreeDThirdPersonActionsCallbackInterface;
    private readonly InputAction m_PlayerThreeDThirdPerson_Movement;
    public struct PlayerThreeDThirdPersonActions
    {
        private @InputMaster m_Wrapper;
        public PlayerThreeDThirdPersonActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerThreeDThirdPerson_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerThreeDThirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerThreeDThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerThreeDThirdPersonActions instance)
        {
            if (m_Wrapper.m_PlayerThreeDThirdPersonActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerThreeDThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerThreeDThirdPersonActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerThreeDThirdPersonActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerThreeDThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerThreeDThirdPersonActions @PlayerThreeDThirdPerson => new PlayerThreeDThirdPersonActions(this);

    // RTSCamera
    private readonly InputActionMap m_RTSCamera;
    private IRTSCameraActions m_RTSCameraActionsCallbackInterface;
    private readonly InputAction m_RTSCamera_Newaction;
    public struct RTSCameraActions
    {
        private @InputMaster m_Wrapper;
        public RTSCameraActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_RTSCamera_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_RTSCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RTSCameraActions set) { return set.Get(); }
        public void SetCallbacks(IRTSCameraActions instance)
        {
            if (m_Wrapper.m_RTSCameraActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_RTSCameraActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_RTSCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public RTSCameraActions @RTSCamera => new RTSCameraActions(this);

    // FreeCamera
    private readonly InputActionMap m_FreeCamera;
    private IFreeCameraActions m_FreeCameraActionsCallbackInterface;
    private readonly InputAction m_FreeCamera_Newaction;
    public struct FreeCameraActions
    {
        private @InputMaster m_Wrapper;
        public FreeCameraActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_FreeCamera_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_FreeCamera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeCameraActions set) { return set.Get(); }
        public void SetCallbacks(IFreeCameraActions instance)
        {
            if (m_Wrapper.m_FreeCameraActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_FreeCameraActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_FreeCameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public FreeCameraActions @FreeCamera => new FreeCameraActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayer2DActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IPlayer3DFPActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IPlayerThreeDThirdPersonActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IRTSCameraActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IFreeCameraActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
