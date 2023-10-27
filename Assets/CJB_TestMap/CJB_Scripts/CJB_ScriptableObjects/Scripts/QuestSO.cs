using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class QuestSO : ScriptableObject
{
    [field: SerializeField] public int questIndex { get; private set; }
    [field: SerializeField] public string questName { get; private set; }
    [field: SerializeField] public QuestType questType { get; private set; }
    [field: SerializeField] public string questDescription { get; private set; }
    [field: SerializeField] public string questCondition { get; private set; } //퀘스트 완료조건
    [field: SerializeField] public string questReward { get; private set; }
}