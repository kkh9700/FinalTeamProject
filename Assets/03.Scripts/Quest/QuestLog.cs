using TMPro;
using UnityEngine;



public class QuestLog : MonoBehaviour
{
    //gameobject 
    public GameObject questLogPanel;

    //questlog
    [SerializeField] TMP_Text[] questLogName;
    public TMP_Text questLogSelected;
    public TMP_Text questLogDescription;
    public TMP_Text questLogRewards;

    PlayerData player;
    

    public void Start()
    {
        player = GameManager.Instance.data;    
        
    }

    public void UpdateQuestLogUI() //questLog에 선택된 퀘스트 정보 표시
    {
        if (player != null && player.acceptQuest != null)
        {
            for (int i = 0; i < questLogName.Length; i++)
            {
                questLogName[i].text = "";
            }
            questLogSelected.text = "";
            questLogDescription.text = "";
            questLogRewards.text = "";

            foreach (var acceptedQuest in player.acceptQuest)
            {
                if (acceptedQuest != null)
                {
                    int questIndex = acceptedQuest.questIndex;

                    if (questIndex >= 0 && questIndex < questLogName.Length)
                    {
                        questLogName[questIndex].text = acceptedQuest.questName;
                    }
                }
                else
                {
                    Debug.LogWarning("acceptedQuest가 null입니다.");
                }
            }
            

        }
        else
        {
            Debug.LogWarning("player 또는 player.acceptQuest가 null입니다.");

        }
    }


    public void OnQuestObjectClick(QuestSO quest) //questLog에서 퀘스트를 하나하나 선택
    {
        ShowLogQuestDetails(quest);

    }

    private void ShowLogQuestDetails(QuestSO selectedQuest) // questLog에서 선택된 퀘스트 정보 표시
    {

        questLogSelected.text = selectedQuest.questName;
        questLogDescription.text = selectedQuest.questDescription;
        questLogRewards.text = selectedQuest.questReward;
    }

    
}
    
