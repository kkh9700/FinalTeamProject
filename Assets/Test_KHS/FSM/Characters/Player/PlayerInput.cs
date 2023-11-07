using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputAction InputActions { get; private set; }
    // PlayerInputAction 안에 있는 PlayerActions를 쓴다.
    public PlayerInputAction.PlayerActions PlayerActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputAction();

        PlayerActions = InputActions.Player;
    }

    /// <summary>
    /// InputActions을 활성화 한다.
    /// </summary>
    private void OnEnable()
    {
        InputActions.Enable();
    }

    /// <summary>
    /// InputActions을 비활성화 한다.
    /// </summary>
    private void OnDisable()
    {
        InputActions.Disable();
    }
}