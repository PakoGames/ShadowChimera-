using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShadowChimera
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset m_inputActionsAsset;
        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private float m_speedMove;

        private InputActionMap m_playerMap;
        private InputAction m_moveAction;

        private void Awake()
        {
            m_playerMap = m_inputActionsAsset.FindActionMap("Player");
            m_moveAction = m_playerMap.FindAction("Move");



        }

        private void OnEnable()
        {
            m_playerMap.Enable();

           
        }

        private void OnDisable()
        {
            m_playerMap.Disable();
        }

        private void Update()
        {
            

            var move = m_moveAction.ReadValue<Vector2>();
            if (move != Vector2.zero)
            {
                Vector3 dir = new Vector3(move.x, 0f, move.y);
                m_characterController.SimpleMove(dir * m_speedMove);
            }
        }
    }
}
