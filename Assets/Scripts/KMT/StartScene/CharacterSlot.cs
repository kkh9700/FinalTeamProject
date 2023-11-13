using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [SerializeField] Vector3 characterPos;
    [SerializeField] Quaternion look;
    [SerializeField] GameObject createButton;
    [SerializeField] TextMeshProUGUI characterName, characterLevel, characterJob;

    GameObject character;

    PlayerCondition conditon;
    PlayerData data;
    GameManager gameManager;

    Animator animator;
    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    private void OnEnable()
    {
        if (character != null)
        {
            conditon = character.GetComponent<PlayerCondition>();
            data = conditon.playerData;
            animator = character.GetComponent<Animator>();
            TextUpdate(data);
        }
        else
        {
            TextOpen(false);
        }
    }
    public void CreateCharacter(GameObject obj, PlayerData data)
    {
        if(character == null)
        {
            character = Instantiate(obj);
            character.SetActive(true);
            conditon = character.AddComponent<PlayerCondition>();
            conditon.playerData = data;
            animator = character.GetComponent<Animator>();
            conditon.Initialize();
        }
    }
    public void SetActiceCharacter()
    {
        if(character == null)
        {
            return;
        }
        character.SetActive(false);
    }
    public void DeleteCharacter()
    {
        if (character != null)
        {
            if (gameManager.DeleteCharacter(StringManager.JsonPath, data.name))
            {
                ClearSlot();
            }
            else
            {
                Debug.Log("실패했습니다");
            }
        }
        else
        {
            Debug.Log("캐릭터 선택해줘");
        }
    }
    public void ClearSlot()
    {
        Destroy(character);
        TextOpen(false);
        character = null;
    }
    public void ChoiceSlot()
    {
        if(character != null)
        {
            animator.SetTrigger("Choice");
        }
    }
    void TextOpen(bool isChar)
    {
        characterName.gameObject.SetActive(isChar);
        characterLevel.gameObject.SetActive(isChar);
        characterJob.gameObject.SetActive(isChar);
        createButton.SetActive(!isChar);
    }
    void TextUpdate(PlayerData data)
    {
        character.name = data.name;
        character.transform.position = characterPos;
        character.transform.localScale = new Vector3(3, 3, 3);
        character.transform.rotation = look;
        characterName.text = character.name;
        characterLevel.text = data.level.ToString();
        characterJob.text = data.job.ToString();
        TextOpen(true);
    }
    public void ChangeSlot(GameObject obj,PlayerData data)
    {
        if(character != null)
        {
            ClearSlot();
        }
        CreateCharacter(obj, data);
        TextUpdate(data);
    }
    public void StartCharacter()
    {
        if (character != null)
        {
            gameManager.player = data;
        }
        else
        {
            Debug.Log("캐릭터 선택해줘");
        }
    }
}
