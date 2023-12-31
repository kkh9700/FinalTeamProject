using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.TextCore.Text;
using System.Linq;

public class SelectCanvasManager : Singleton<SelectCanvasManager>
{
    public ChangerSlot[] changerSlots;

    int selectedSlot;
    [SerializeField] CharacterSlot[] characterSlots;
    [SerializeField] GameObject[] baseCharacters;

    public List<string> playerName = new List<string>();

    private PlayerData[] playerDatas = new PlayerData[4];
    public PlayerData[] PlayerDatas { get { return playerDatas; } }
    private void OnEnable()
    {
        selectedSlot = -1;
    }
    private void Start()
    {
        if (Directory.Exists(StringManager.JsonPath))
        {
            string[] jsons = Directory.GetFiles(StringManager.JsonPath, "*.json")
                            .Where(file => !string.IsNullOrEmpty(Path.GetFileName(file)))
                            .ToArray();

            if (jsons.Length > 0)
            {
                for (int i = 0; i < jsons.Length; i++)
                {
                    playerName.Add(Path.GetFileNameWithoutExtension(jsons[i]));
                }
                if (playerName.Count > 0)
                {
                    foreach (string one in playerName)
                    {
                        PlayerData data = GameManager.Instance.LoadPlayerDataFromJson(StringManager.JsonPath, one);
                        playerDatas[data.playerIndex] = data;
                        characterSlots[data.playerIndex].CreateCharacter(baseCharacters[(int)data.job], data);
                    }
                }
            }
        }

        for (int i = 0; i < characterSlots.Length; i++)
        {
            characterSlots[i].gameObject.SetActive(true);
            characterSlots[i].SlotSetting();
        }
    }
    public void SelectSlot(int slotIndex)
    {
        selectedSlot = slotIndex;
        characterSlots[selectedSlot].ChoiceSlot();
    }

    public void StartButon()
    {
        if (selectedSlot == -1)
        {
            UIManager.Instance.ActivePopUpUI("게임 시작", "캐릭터를 선택해 주세요.", null);
            return;
        }
        characterSlots[selectedSlot].StartCharacter();
    }


    #region SlotChangeSystem
    public void SlotPopUpOpen()
    {
        UIManager.Instance.ActivePopUpUI("캐릭터 슬롯 변경", "정말 변경 하시겠습니까?", SlotChangeButton);
    }
    void SlotChangeButton()
    {
        for (int i = 0; i < playerDatas.Length; i++)
        {
            if (playerDatas[i] != null)
            {
                GameManager.Instance.SavePlayerDataToJson(StringManager.JsonPath, playerDatas[i].name, playerDatas[i]);
            }
        }
        for (int i = 0; i < characterSlots.Length; i++)
        {
            if (playerDatas[i] != null)
            {
                characterSlots[i].ChangeSlot(baseCharacters[(int)playerDatas[i].job], playerDatas[i]);
            }
            else
            {
                characterSlots[i].ClearSlot();
            }
        }
    }
    public void ClickUpButton(int slotIndex)
    {
        if (changerSlots[slotIndex - 1].PlayerData == null)
        {
            changerSlots[slotIndex - 1].SetData(slotIndex - 1, changerSlots[slotIndex].PlayerData);
            changerSlots[slotIndex].SetData(slotIndex, null);
            playerDatas[slotIndex - 1] = playerDatas[slotIndex];
            playerDatas[slotIndex] = null;
        }
        else
        {
            PlayerData data = changerSlots[slotIndex - 1].PlayerData;
            changerSlots[slotIndex - 1].SetData(slotIndex - 1, changerSlots[slotIndex].PlayerData);
            changerSlots[slotIndex].SetData(slotIndex, data);
            playerDatas[slotIndex - 1] = playerDatas[slotIndex];
            playerDatas[slotIndex] = data;
        }
        for (int i = 0; i < characterSlots.Length; i++)
        {
            characterSlots[i].data = playerDatas[i];
        }
        SlotDataReboot();
    }
    public void ClickDownButton(int slotIndex)
    {
        if (changerSlots[slotIndex + 1].PlayerData == null)
        {
            changerSlots[slotIndex + 1].SetData(slotIndex + 1, changerSlots[slotIndex].PlayerData);
            changerSlots[slotIndex].SetData(slotIndex, null);
            playerDatas[slotIndex + 1] = playerDatas[slotIndex];
            playerDatas[slotIndex] = null;
        }
        else
        {
            PlayerData data = changerSlots[slotIndex + 1].PlayerData;
            changerSlots[slotIndex + 1].SetData(slotIndex + 1, changerSlots[slotIndex].PlayerData);
            changerSlots[slotIndex].SetData(slotIndex, data);
            playerDatas[slotIndex + 1] = playerDatas[slotIndex];
            playerDatas[slotIndex] = data;
        }
        SlotDataReboot();
    }
    void SlotDataReboot()
    {
        for (int i = 0; i < characterSlots.Length; i++)
        {
            characterSlots[i].data = playerDatas[i];
        }
    }
    #endregion SlotChangeSystem
    #region CreateCharacterSystem
    public void CreateButton(int slotIndex)
    {
        selectedSlot = slotIndex;
        for (int i = 0; i < characterSlots.Length; i++)
        {
            characterSlots[i].SetActiceCharacter();
        }
        StartSceneManager.Instance.OpenCreateCanvas();
    }
    public void CreateCharacter(string name, PlayerData data)
    {
        if(name.Length <= 1)
        {
            UIManager.Instance.ActivePopUpUI("캐릭터 생성", "이름은 최소 2자 입니다.", null);
            return;
        }
        if (name.Length > 6)
        {
            UIManager.Instance.ActivePopUpUI("캐릭터 생성", "이름은 최대 6자 까지입니다.", null);
            return;
        }

        if (!playerName.Contains(name))
        {
            data.name = name;
            data.playerIndex = selectedSlot;
            data.level = 1;
            GameManager.Instance.SavePlayerDataToJson(StringManager.JsonPath, data.name, data);
            PlayerData characterData = GameManager.Instance.LoadPlayerDataFromJson(StringManager.JsonPath, data.name);
            characterSlots[characterData.playerIndex].CreateCharacter(baseCharacters[(int)characterData.job], characterData);
            playerDatas[characterData.playerIndex] = characterData;
            playerName.Add(name);
            StartSceneManager.Instance.OpenSelectCanvas();
        }
        else
        {
            UIManager.Instance.ActivePopUpUI("캐릭터 생성", "이미 있는 이름입니다.", null);
        }
    }
    public void DeleteButton()
    {
        if (selectedSlot == -1)
        {
            Debug.Log("캐릭터를 선택해주세요");
            return;
        }
        characterSlots[selectedSlot].DeleteButton();
    }
    public void DeleteCharacter(PlayerData data)
    {
        changerSlots[data.playerIndex].DeleteCharacter();
        playerDatas[data.playerIndex] = null;
        playerName.Remove(data.name);
    }
    #endregion CreateCharacterSystem
}
