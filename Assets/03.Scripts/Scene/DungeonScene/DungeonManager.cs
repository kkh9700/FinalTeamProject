using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance;

    public int spawnIdx = 0;
    public int goblinkillCount = 0;

    [field: Header("Audio")]
    [SerializeField] private AudioClip DungeonSound;

    [field: Header("Prefabs")]
    public GameObject monsterPrefab;
    public GameObject goblinPrefab;
    public GameObject swordGoblinPrefab;
    public GameObject orkberserkerPrefab;
    public GameObject necromanserPrefab;

    //TODO: 골드, (hp,mp포션), 퀘스트 템, 장비 (Item.class)
    //Item ObjectPool

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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        //사운드 플레이
        SoundManager.Instance.BGMPlay(DungeonSound);

        monsterObjectPool = new ObjectPool<Monster>(monsterPrefab.GetComponent<Monster>(), 20);
        goblinObjectPool = new ObjectPool<Monster>(goblinPrefab.GetComponent<Monster>(), 10);
        swordGoblinObjectPool = new ObjectPool<Monster>(swordGoblinPrefab.GetComponent<Monster>(), 20);
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

    public GameObject SpawnMonster(MonsterType monsterType, int spawnListIdx)
    {
        Vector3 spawnPos = spawnList[spawnListIdx].ReturnRandomPosition();

        if(MonsterType.Necromanser == monsterType)
        {
            Boss boss = null;
            boss = necrmanserObjectPool.GetObject();
            boss.BossNavMeshAgent.enabled = false;
            boss.gameObject.transform.position = spawnPos;
            boss.BossNavMeshAgent.enabled = true;

            return boss.gameObject;
        }

        Monster monster = null;
        switch (monsterType)
        {
            case MonsterType.Goblin:
                monster = goblinObjectPool.GetObject();
                monster.objectPoolReturn += goblinObjectPool.ReturnObject;

                //고블린 몬스터타입이 죽을때마다 goblinKillCount가 늘어나게끔
                monster.objectPoolReturn += GoblinKilled;
                break;
            case MonsterType.SwordGoblin:
                monster = swordGoblinObjectPool.GetObject();
                monster.objectPoolReturn += swordGoblinObjectPool.ReturnObject;
                break;
            case MonsterType.Monster:
                monster = monsterObjectPool.GetObject();
                monster.objectPoolReturn += monsterObjectPool.ReturnObject;
                break;
            case MonsterType.OrkBerserk:
                monster = orkberserkerObjectPool.GetObject();
                monster.objectPoolReturn += orkberserkerObjectPool.ReturnObject;
                break;
        }

        monster.EnemyNavMeshAgent.enabled = false;
        monster.gameObject.transform.position = spawnPos;
        monster.EnemyNavMeshAgent.enabled = true;

        return monster.gameObject;
    }
    public void GoblinKilled(Monster goblin)
    {
        goblinkillCount++;
        Debug.Log("잡은 고블린수: " + goblinkillCount);
    }

    public void Spawn()
    {
        for(int i = 0; i < spawnList[spawnIdx].spawnEnemyList.Count; i++)
        {
            for(int j = 0; j < spawnList[spawnIdx].spawnEnemyList[i].spawnCount; j++)
            {
                GameObject spawnedMonster = SpawnMonster(spawnList[spawnIdx].spawnEnemyList[i].monsterType, spawnIdx);
                if (spawnedMonster == null)
                {
                    Debug.LogError("Failed to spawn monster of type: " + spawnList[spawnIdx].spawnEnemyList[i].monsterType);
                }
            }
        }
    }
}
