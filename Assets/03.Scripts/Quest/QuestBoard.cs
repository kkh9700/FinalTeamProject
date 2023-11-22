using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour
{
    //gameobject
    //public GameObject mainCompletePop;  
    public GameObject acceptPopup;
    public GameObject cancelPopup;
    public GameObject questLogPanel;
    [SerializeField] Button[] questButton;

    //quest board
    [SerializeField] TMP_Text[] questTitleText;
    public TMP_Text questDescriptionText;
    public TMP_Text questConditionText;
    public TMP_Text questRewardText;
    [SerializeField] Button acceptButton;

    //questlog
    [SerializeField] TMP_Text[] questLogName;
    public TMP_Text questLogSelected;
    public TMP_Text questLogDescription;
    public TMP_Text questLogRewards;

    //quest progress
    [SerializeField] TMP_Text questProgmonsterName;
    [SerializeField] TMP_Text questProgitemName;
    [SerializeField] TMP_Text questProgconverseName;
    [SerializeField] TMP_Text questProgInfinitemonsterName;
    public TMP_Text questProgmainName;

    [SerializeField] List<QuestSO> quests;
    public static UIManager Instance;
    private DungeonManager dungeonManager;
    private int dropResourceitemcount;

    
    private QuestController controller;
    int goblinKills = DungeonManager.Instance.goblinkillCount;

    //메인퀘스트 관련
    private ChoiceDungeon choiceDungeon;
    //public float fadeDuration = 1f;

    public List<QuestSO> Quests { get { return quests; } }

    //NPCSO npcs;
    //ItemSO itemSO;
    QuestSO selectQuest;
    PlayerData player;

    public void Start()
    {
        player = GameManager.Instance.player;
        dungeonManager = DungeonManager.Instance;

        controller = FindAnyObjectByType<QuestController>();
        choiceDungeon = FindObjectOfType<ChoiceDungeon>();
        //이벤트 구독
        if (choiceDungeon != null)
        {
            ChoiceDungeon.DungeonInteractionPopupActivated += OnDungeonInteractionPopupActivated;
        }

        InitializeQuestList();
        acceptButton.onClick.AddListener(() => { AcceptQuest(selectQuest); });
    }
    private void OnDungeonInteractionPopupActivated()
    {
        QuestSO selectedQuest = GetMainQuest();
        UpdateMainQuestProgress(selectedQuest );
    }

    private QuestSO GetMainQuest()
    {
        QuestSO mainQuest = quests[4];
        return mainQuest;
    }

    private void InitializeQuestList()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            int index = i;
            questTitleText[i].text = quests[i].questName;
            questButton[i].onClick.AddListener(() => { ShowQuestDetails(quests[index]); });
        }
    }
    private void ShowQuestDetails(QuestSO selectedQuest) //questBoard에서 표시되는 퀘스트 정보
    {
        questDescriptionText.text = selectedQuest.questDescription;
        questConditionText.text = selectedQuest.questCondition;
        questRewardText.text = selectedQuest.questReward;
        selectQuest = selectedQuest;
    }
    private bool IsQuestAlreadyAccepted(QuestSO quest) // 같은 타입의 퀘스트는 한번만 받게끔
    {
        if (player.acceptQuest.Contains(quest))
        {
            return true;
        }
        return false;
    }
    private void AcceptQuest(QuestSO quest) // questBoard에서 퀘스트를 수락
    {
        if (!IsQuestAlreadyAccepted(quest))
        {
            player.acceptQuest.Add(quest);
            acceptPopup.SetActive(true);
            UpdateQuestLogUI();
            ShowQuestProgress(quest);

            foreach (var npc in quest.relatedNPCs)
            {
                if (npc != null)
                {
                    npc.hasQuest = true;

                }

            }

        }
        else
        {
            Debug.Log("Quest already accepted!");
            cancelPopup.SetActive(true);
        }
    }



    private void UpdateQuestLogUI() //questLog에 선택된 퀘스트 정보 표시
    {
        //questLogName.text = "";
        for (int i = 0; i < questLogName.Length; i++)
        {
            questLogName[i].text = "";
        }
        questLogSelected.text = "";
        questLogDescription.text = "";
        questLogRewards.text = "";

        foreach (var acceptedQuest in player.acceptQuest)
        {

            int questIndex = acceptedQuest.questIndex;


            if (questIndex >= 0 && questIndex < questLogName.Length)
            {

                questLogName[questIndex].text = acceptedQuest.questName;
            }



        }


        questLogSelected.text = "";
        questLogDescription.text = "";
        questLogRewards.text = "";


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

    public void ShowQuestProgress(QuestSO selectedQuest) //questProgress 표시창
    {
        if (selectedQuest.questType == QuestType.ConversationQuest) //대화퀘스트
        {
            foreach (var npc in selectedQuest.relatedNPCs)
            {

                questProgconverseName.text = selectedQuest.questName + "\n - " + npc.conversationCount + " / " + selectedQuest.questComplete;

            }
        }
        if (selectedQuest.questType == QuestType.ItemQuest) //아이템퀘스트 = TODO:드롭되는 아이템 갯수 카운트 해서 '현재상황'에 반영
        {
            questProgitemName.text = selectedQuest.questName + "\n - " + "현재상황 / " + selectedQuest.questComplete;
        }
        else if (selectedQuest.questType == QuestType.MonsterQuest) //몬스터퀘스트 = TODO:goblin 처치 시마다 처치한 마릿수 카운트 
        {
            questProgmonsterName.text = selectedQuest.questName + "\n - " + goblinKills  + "/ " + selectedQuest.questComplete;

            if(goblinKills >= selectedQuest.questComplete)
            {
                questProgmonsterName.color = Color.green;
                //여기에 ItemAddTest추가
                //ItemAddTest(selectedQuest);
            }
        }
        else if (selectedQuest.questType == QuestType.InfiniteMonsterQuest) //무한몬스터퀘스트
        {
            questProgInfinitemonsterName.text = selectedQuest.questName + "\n - " +goblinKills + "/ " + selectedQuest.questComplete;
            if (goblinKills >= selectedQuest.questComplete)
            {
                questProgmonsterName.color = Color.green;
                //여기에 새로운 퀘스트 추가 - 150마리 잡는 퀘스트
                
            }
        }
        else if (selectedQuest.questType == QuestType.MainQuest) //메인퀘스트 =  TODO:던전 입구 도착시에 퀘스트 완료시키기
        {
            questProgmainName.text = selectedQuest.questName + "\n - " + "0 / " + selectedQuest.questComplete;
            UpdateMainQuestProgress(selectedQuest);
    
        }
    }
    public void UpdateMainQuestProgress(QuestSO selectedQuest)
    {

        if (choiceDungeon != null && choiceDungeon.IsDungeonInteractionPopupActive())
        {
            Debug.Log("UpdateMainQuest이 null이 아니다");
            // dungeonInteractionPopup이 활성화되어 있을 때       
            questProgmainName.color = Color.green;
            questProgmainName.text = selectedQuest.questName + "\n - " + "1 / " + selectedQuest.questComplete;

            ItemSO newItem = CreateNewItemFromQuest(selectedQuest);
            ItemAddTest(newItem);
        }
        else if (choiceDungeon == null)
        {
            // choiceDungeon이 null 
            Debug.Log("choiceDungeon이 Null입니다");
        }
        else
        {
            //dungeonInteractionPopup이 비활성화일 때
            Debug.Log("popup이 비활성화 상태");
        }
    }
    private ItemSO CreateNewItemFromQuest(QuestSO selectedQuest)
    {
        
        ItemSO newItem = new ItemSO();
        newItem.type = ItemType.Gold;
        Debug.Log("Main퀘스트 보상받음");

        return newItem;
    }
    void OnDestroy()
    {
        // 이벤트 구독 해제
        if (choiceDungeon != null)
        {
            ChoiceDungeon.DungeonInteractionPopupActivated -= OnDungeonInteractionPopupActivated;
        }
    }
    public void CurrentDropItemCount() //특정 리소스 아이템을 주울때마다 카운트 Up -- 완료 안됨 임시
    {
        dropResourceitemcount++;
    }
    

    public void ItemAddTest(ItemSO itemSO) // 이건 예시고 이걸 비슷하게 해서 만드는걸로 수정...
    {
        if(Instance != null)
        {
            Instance.OnUIInputEnable();
        }
        Item item;
        switch (itemSO.type)
        {
            case ItemType.Equip:
                item = new EquipItem(itemSO);
                break;
            case ItemType.Consumes:
                item = new UseItem(itemSO);
                break;           
            default:
                item = new ResourceItem(itemSO);
                break;
        }
        if (UIManager.Instance.GetInventory().AddItem(item))
        {
            // 퀘스트 완료처리
            foreach (var acceptedQuest in player.acceptQuest)
            {
                if (acceptedQuest.questIndex == 1) // 아이템 퀘스트
                {
                    // 해당 아이템 퀘스트의 조건 충족 및 보상 처리
                    if(dropResourceitemcount >= selectQuest.questComplete) 
                    {
                        if (controller != null)
                        {
                            controller.ShowPopup();
                            controller.Invoke("HidePopup", 2f);

                        }
                        else if (controller == null)
                        {
                            Debug.Log("Null입니다");
                        }

                    }
                }

                // 대화퀘스트 완료처리는 npcInteraction에              

                else if (acceptedQuest.questIndex == 0) //몬스터 퀘스트
                {
                    
                    if (goblinKills >= acceptedQuest.questComplete)
                    {
                        // 몬스터 퀘스트 완료 처리 로직 추가
                        if (controller != null)
                        {
                            controller.ShowPopup();
                            controller.Invoke("HidePopup", 2f);

                        }
                        else if (controller == null)
                        {
                            Debug.Log("Null입니다");
                        }

                    }
                }
                else if (acceptedQuest.questIndex == 3) //무한 몬스터 퀘스트
                {
                    
                    if (goblinKills >= acceptedQuest.questComplete)
                    {
                        // 무한 몬스터 퀘스트 완료 처리 로직 추가
                        // 다음 무한 퀘스트 추가 해주기
                        if (controller != null)
                        {
                            controller.ShowPopup();
                            controller.Invoke("HidePopup", 2f);

                        }
                        else if (controller == null)
                        {
                            Debug.Log("Null입니다");
                        }

                    }
                }
                else if(acceptedQuest.questIndex == 4) // 메인 퀘스트
                {
                    //던전에 입장을 했을시에 퀘스트 완료 처리
                    
                    if (choiceDungeon != null && choiceDungeon.IsDungeonInteractionPopupActive())
                    {
                        if(controller != null)
                        {
                            controller.ShowPopup();
                            controller.Invoke("HidePopup", 2f);

                        }
                        else if(controller == null)
                        {
                            Debug.Log("Null입니다");
                        }
                        

                    }
                }
            }
        }
        else
        {
            Debug.Log("인벤토리가 꽉찼습니다.");
            // 팝업 띄워줘서 인벤토리가 꽉찼습니다.
            // 정리하고 다시 완료 버튼 누르게
        }

    }
   
    






}
