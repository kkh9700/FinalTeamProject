using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPassageChecker : MonoBehaviour
{
    [SerializeField] private List<FadeOutObject> fadeOutObjects;
    private DungeonManager dungeonManager;
    private void Start()
    {
        dungeonManager = DungeonManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collider!");
            Debug.Log(dungeonManager.CheckAllMonster());
            if (dungeonManager.CheckAllMonster())
            {
                for(int i = 0; i < fadeOutObjects.Count; i++)
                {
                    fadeOutObjects[i].FadeOut();
                }
                dungeonManager.spawnIdx++;
                if (dungeonManager.spawnList.Count == dungeonManager.spawnIdx)
                {
                    //TODO : 클리어 일단 시간 멈춰놓기
                    //Time.timeScale = 0;
                }
                else
                {
                    dungeonManager.Spawn();
                }
                
            }
        }
    }
    public void SetDungeonManager(DungeonManager manager)
    {
        dungeonManager = manager;
    }

}
