using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{

    [field: Header("References")]
    [field: SerializeField] public BossSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public BossAnimationData bossAnimationData { get; private set; }

    [field: Header("Bullet")]
    [field: SerializeField] public GameObject bossBullet1CastSpell { get; private set; }
    [field: SerializeField] private GameObject bossBullet1Obj;
    [field: SerializeField] private GameObject bossBullet2Obj;

    public ObjectPool<BossBullet> pattern1Bullet { get; private set; }
    public ObjectPool<BossSpell> pattern2Bullet { get; private set; }

    public event Action<Boss> objectPoolReturn;
    [field: SerializeField] public Transform bulletSpawnPoint {get; private set;}


    public NavMeshAgent BossNavMeshAgent { get; private set; }
    public Animator Animator { get; private set; }

    private BossStateMachine stateMachine;        
    [field: SerializeField] public BossWeapon Weapon1 { get; private set; }
    [field: SerializeField] public BossWeapon Weapon2 { get; private set; }
    public BossHealth BossHealth { get; private set; }


    private void Awake()
    {
        bossAnimationData.Initialize();

        Animator = GetComponent<Animator>();
        BossNavMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new BossStateMachine(this);
        BossHealth = GetComponent<BossHealth>();
        BossHealth.InitEnemyHealth(Data.Health, Data.Name);

        bossBullet1CastSpell.SetActive(false);

        Weapon1.SetAttack(Data.AttackPatternInfoDatas[0].Damage);
        Weapon2.SetAttack(Data.AttackPatternInfoDatas[1].Damage);

    }

    private void Start()
    {
        InitNavMesh();
        Initboss();
        BossHealth.OnDie += OnDie;
        pattern1Bullet = new ObjectPool<BossBullet>(bossBullet1Obj.GetComponent<BossBullet>(), 12);
        pattern2Bullet = new ObjectPool<BossSpell>(bossBullet2Obj.GetComponent<BossSpell>(), 1);
    }

    //NavMeshAent 초기화
    private void InitNavMesh()
    {
        BossNavMeshAgent.speed = Data.BaseSpeed;
        BossNavMeshAgent.autoBraking = false;
    }
    private void Initboss()
    {
        BossHealth.InitEnemyHealth(Data.Health, Data.Name);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();

        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    void OnDie()
    {
        Animator.SetTrigger("Die");
        Invoke("AfterAnimationComplete", Animator.GetCurrentAnimatorStateInfo(0).length);
        GameManager.Instance.condition.AddExp(Data.Exp);
    }

    void AfterAnimationComplete()
    {
        objectPoolReturn?.Invoke(this);
        Initboss();
    }

}
