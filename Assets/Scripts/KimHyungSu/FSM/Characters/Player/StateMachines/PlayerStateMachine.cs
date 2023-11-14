using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    #region States
    public PlayerIdleState IdleState { get; }
    public PlayerWalkState WalkState { get; }

    public PlayerAttackState AttackState { get; }
    #endregion States

    // 
    // 움직임을 받는다.
    public Vector3 MovementInput { get; set; }
    // 이동 속도이다.
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public Transform MainCameraTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);

        AttackState = new PlayerAttackState(this);

        MovementSpeed = player.Data.GroundedData.BaseSpeed;
    }
}