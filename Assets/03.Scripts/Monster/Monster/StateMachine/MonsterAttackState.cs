using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    private bool alreadyAppliedDealing;
    private bool alreadyAppliedForce;
    public MonsterAttackState(MonsterStateMachine monsterStateMachine) : base(monsterStateMachine)
    {
        stateMachine = monsterStateMachine;
    }
    public override void Enter()
    {
        alreadyAppliedForce = false;
        alreadyAppliedDealing = false;
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(stateMachine.Monster.monsterAnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Monster.monsterAnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        float normalizedTime = GetNormalizedTime(stateMachine.Monster.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (!alreadyAppliedDealing && normalizedTime >= stateMachine.Monster.Data.Dealing_Start_TransitionTime)
            {
                stateMachine.Monster.Weapon.SetAttack(stateMachine.Monster.Data.Damage);
                stateMachine.Monster.Weapon.gameObject.SetActive(true);
                alreadyAppliedDealing = true;
            }else if (alreadyAppliedDealing && normalizedTime >= stateMachine.Monster.Data.Dealing_End_TransitionTime)
            {
                stateMachine.Monster.Weapon.gameObject.SetActive(false);
                alreadyAppliedDealing = false;
            }

        }
        else
        {
            if (IsInAttackRange())
            {
                stateMachine.ChangeState(stateMachine.AttackState);
                return;
            }
            else if (IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.ChasingState);
                return;
            }
        }
    }
    private bool IsInAttackRange()
    {
        // if (stateMachine.Target.IsDead) { return false; }

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.Monster.Data.AttackRange * stateMachine.Monster.Data.AttackRange;
    }
}
