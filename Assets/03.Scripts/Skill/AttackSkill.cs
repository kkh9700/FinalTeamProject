using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackSkill : Skill, IUsable
{

    public int damage;
    public int increasedDamagePerLevel;
    public delegate void SkillUsedDelegate(float cooltime);
    public event SkillUsedDelegate ApplyCoolTime;

    public AttackSkill(SkillSO skillSO) : base(skillSO)
    {
        if (skillSO is AttackSkillSO)
        {
            AttackSkillSO attackSkillSO = (AttackSkillSO)skillSO;

            damage = attackSkillSO.damage;
            increasedDamagePerLevel = attackSkillSO.increasedDamagePerLevel;
        }
    }


    // TODO: 이펙트, 범위, 대미지
    public void Use()
    {
        if (GameManager.Instance.condition.ConsumeMp(manaCost))
        {
            float totalDamage = damage + level * increasedDamagePerLevel;
            GameManager.Instance.player.skillRange[index].Set(totalDamage);
            GameManager.Instance.player.IsAttackSkill[index] = true;
            ApplyCoolTime?.Invoke(cooltime);
        }
        else
        {
            // TODO: mp가 부족할 때 팝업창 띄우기
        }

    }
}