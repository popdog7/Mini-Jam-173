using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler on_jump_action;
    private PlayerInputActions player_input_actions;

    private void Awake()
    {
        player_input_actions = new PlayerInputActions();
        player_input_actions.Player.Enable();

        player_input_actions.Player.Jump.performed += JumpPerformed;
    }

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        on_jump_action?.Invoke(this, EventArgs.Empty);
    }

    public float GetHorizontalMovement()
    {
        return player_input_actions.Player.Move.ReadValue<float>();
    }
}
