using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    UnityAction leaveDungeonAction;
    private void Start()
    {
        leaveDungeonAction = LeaveDungeon;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ActivePopUpUI("확인", "던전에서 나가시겠습니까?", leaveDungeonAction);
        }
    }

    public void LeaveDungeon()
    {
        GameManager.Instance.data.currentPlayerPos = new Vector3(-118.17f,0f,-93.98f);
        SceneLoadManager.LoadScene("NewTownScene");
    }
}
