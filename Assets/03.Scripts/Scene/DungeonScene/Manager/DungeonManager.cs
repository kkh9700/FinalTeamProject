using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DungeonManager : Singleton<DungeonManager>
{
    public int spawnIdx;

    [field: Header("Audio")]
    [SerializeField] private AudioClip DungeonSound;

    [field: Header("Prefabs")]
    public GameObject monsterPrefab;
    public GameObject goblinPrefab;
    public GameObject swordGoblinPrefab;
    public GameObject orkberserkerPrefab;
    public GameObject necromanserPrefab;

    //Monster ObjectPool
    public ObjectPool<Monster> monsterObjectPool { get; private set; }
    public ObjectPool<Monster> goblinObjectPool { get; private set; }
    public ObjectPool<Monster> swordGoblinObjectPool { get; private set; }
    public ObjectPool<Monster> orkberserkerObjectPool { get; private set; }
    public ObjectPool<Boss> necrmanserObjectPool { get; private set; }

    [field: Header("Checker")]
    public List<PlayerPassageChecker> checkerList = new List<PlayerPassageChecker>();
    [field: Header("Spawn")]
    public List<MonsterSpawn> spawnList = new List<MonsterSpawn>();


    private void Start()
    {
        //사운드 플레이
        SoundManager.Instance.BGMPlay(DungeonSound);

        UIManager.Instance.ActivePlayerUI(true);
        GameManager.Instance.condition.GenerateResource();

        SetSpawnNum();

        monsterObjectPool = new ObjectPool<Monster>(monsterPrefab.GetComponent<Monster>(), 30);
        goblinObjectPool = new ObjectPool<Monster>(goblinPrefab.GetComponent<Monster>(), 20);
        swordGoblinObjectPool = new ObjectPool<Monster>(swordGoblinPrefab.GetComponent<Monster>(), 10);
        orkberserkerObjectPool = new ObjectPool<Monster>(orkberserkerPrefab.GetComponent<Monster>(), 10);
        necrmanserObjectPool = new ObjectPool<Boss>(necromanserPrefab.GetComponent<Boss>(), 1);

        Spawn();
    }

    public bool CheckAllMonster()
    {
        return monsterObjectPool.CheckListSize() && goblinObjectPool.CheckListSize()
               && swordGoblinObjectPool.CheckListSize() && orkberserkerObjectPool.CheckListSize()
               && necrmanserObjectPool.CheckListSize();
    }

    public GameObject SpawnMonster(Define.MonsterType monsterType, int spawnListIdx)
    {
        Vector3 spawnPos = spawnList[spawnListIdx].ReturnRandomPosition();

        if (Define.MonsterType.Necromanser == monsterType)
        {
            Boss boss = null;
            boss = necrmanserObjectPool.GetObject();
            boss.objectPoolReturn += necrmanserObjectPool.ReturnObject;
            boss.BossNavMeshAgent.enabled = false;
            boss.gameObject.transform.position = spawnPos;
            boss.BossNavMeshAgent.enabled = true;

            return boss.gameObject;
        }

        Monster monster = null;
        switch (monsterType)
        {
            case Define.MonsterType.Goblin:

                monster = goblinObjectPool.GetObject();
                monster.objectPoolReturn += goblinObjectPool.ReturnObject;

                //고블린 몬스터타입이 죽을때마다 goblinKillCount가 늘어나게끔
                monster.objectPoolReturn += DungeonGoblinKilled;
                break;
            case Define.MonsterType.SwordGoblin:
                monster = swordGoblinObjectPool.GetObject();
                monster.objectPoolReturn += swordGoblinObjectPool.ReturnObject;
                break;
            case Define.MonsterType.Monster:
                monster = monsterObjectPool.GetObject();
                monster.objectPoolReturn += monsterObjectPool.ReturnObject;
                break;
            case Define.MonsterType.OrkBerserk:
                monster = orkberserkerObjectPool.GetObject();
                monster.objectPoolReturn += orkberserkerObjectPool.ReturnObject;
                break;
        }

        monster.EnemyNavMeshAgent.enabled = false;
        monster.gameObject.transform.position = spawnPos;
        monster.EnemyNavMeshAgent.enabled = true;

        return monster.gameObject;
    }
    public void DungeonGoblinKilled(Monster Goblin)
    {
        int kill = GameManager.Instance.goblinkillCount;
        kill++;
        GameManager.Instance.UpdateGoblinKillCount(kill);
        Debug.Log("잡은 고블린수: " + GameManager.Instance.goblinkillCount);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnList[spawnIdx].spawnEnemyList.Count; i++)
        {
            for (int j = 0; j < spawnList[spawnIdx].spawnEnemyList[i].spawnCount; j++)
            {
                GameObject spawnedMonster = SpawnMonster(spawnList[spawnIdx].spawnEnemyList[i].monsterType, spawnIdx);
                if (spawnedMonster == null)
                {
                    Debug.LogError("Failed to spawn monster of type: " + spawnList[spawnIdx].spawnEnemyList[i].monsterType);
                }
            }
        }
    }

    public void SetSpawnNum()
    {
        if (GameManager.Instance.data.currentPlayerPos == new Vector3(0f, 0f, 0f))
        {
            spawnIdx = 0;
        }
        else if (GameManager.Instance.data.currentPlayerPos == new Vector3(247.13f, 0f, 193.55f))
        {
            spawnIdx = 1;
        }
        else if (GameManager.Instance.data.currentPlayerPos == new Vector3(-10f, 4f, 232.68f))
        {
            spawnIdx = 2;
        }
        else if (GameManager.Instance.data.currentPlayerPos == new Vector3(-127.9f, 8f, 340f))
        {
            spawnIdx = 3;
        }
        else if (GameManager.Instance.data.currentPlayerPos == new Vector3(-128.9f, 8f, 377.6f))
        {
            spawnIdx = 4;
        }
        else
        {
            spawnIdx = 0;
        }
    }



    public void SetPlayerPosition(int passageNum)
    {
        switch (passageNum)
        {
            case 0:
                GameManager.Instance.data.currentPlayerPos = new Vector3(0f, 0f, 0f);
                break;
            case 1:
                GameManager.Instance.data.currentPlayerPos = new Vector3(247.13f, 0f, 193.55f);
                break;
            case 2:
                GameManager.Instance.data.currentPlayerPos = new Vector3(-10f, 4f, 232.68f);
                break;
            case 3:
                GameManager.Instance.data.currentPlayerPos = new Vector3(-127.9f, 8f, 340f);
                break;
            case 4:
                GameManager.Instance.data.currentPlayerPos = new Vector3(-128.9f, 8f, 377.6f);
                break;
            case 5:
                GameManager.Instance.data.currentPlayerPos = new Vector3(-129.1f, 12f, 430.5f);
                break;
        }
    }
}
