using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//일반 근접 공격
public class BossAttackOneState : BossBaseState
{
    private bool alreadyAppliedDealing;
    private bool alreadyAppliedForce;
    public BossAttackOneState(BossStateMachine bossStateMachine) : base(bossStateMachine)
    {
        stateMachine = bossStateMachine;
    }
    public override void Enter()
    {
        alreadyAppliedForce = false;
        alreadyAppliedDealing = false;
        base.Enter();
        StartAnimation(stateMachine.Boss.bossAnimationData.Attack1ParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Boss.bossAnimationData.Attack1ParameterHash);
    }

    public override void Update()
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Boss.Animator);
        if (normalizedTime < 1f)
        {
            if (!alreadyAppliedDealing && normalizedTime >= stateMachine.Boss.Data.AttackPatternInfoDatas[0].Dealing_Start_TransitionTime)
            {
                stateMachine.Boss.Weapon1.SetAttack(stateMachine.Boss.Data.AttackPatternInfoDatas[0].Damage);
                stateMachine.Boss.Weapon1.gameObject.SetActive(true);
                alreadyAppliedDealing = true;
            }else if (alreadyAppliedDealing && normalizedTime >= stateMachine.Boss.Data.AttackPatternInfoDatas[0].Dealing_End_TransitionTime)
            {
                stateMachine.Boss.Weapon1.gameObject.SetActive(false);
                alreadyAppliedDealing = false; 
                return;
            }

        }
        else if(normalizedTime > 1f)
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
            return;
        }
    }

}
