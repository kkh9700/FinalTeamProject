using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        // 멈추면
        if (stateMachine.Player.Agent.velocity == Vector3.zero)
        {
            OnStand();
            return;
        }
    }

    protected override void OnMoveStarted(InputAction.CallbackContext context)
    {
        base.OnMoveStarted(context);

        Move();
    }
}