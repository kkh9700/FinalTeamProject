using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public PlayerData data;
    public PlayerCondition condition;

    public int goblinkillCount = 0; // 고블린 잡은 횟수
    public GameObject Myplayer;
    public EventSystem eventSystem;

    public Camera playerCamera;
    public CinemachineVirtualCamera virtualCamera;

    SlotItem slot;

    GameObject obj;

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

        slot = new SlotItem();
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (data.baseObjectPath != null && scene.buildIndex != (int)SceneType.Start && scene.buildIndex != (int)SceneType.Loading)
        {
            CameraSetActive(true);
            obj = Resources.Load<GameObject>(data.baseObjectPath);
            Myplayer = Instantiate<GameObject>(obj, data.currentPlayerPos, data.currentPlayerRot);
            player = Myplayer.GetComponent<Player>();
            condition = Myplayer.AddComponent<PlayerCondition>();
            condition.playerData = data;
            condition.Initialize();
            UIManager.Instance.gameObject.SetActive(true);
            UIManager.Instance.ActivePlayerUI(true);
            UIManager.Instance.GetInventory().Set(LoadItemArrayFromJson(StringManager.ItemJsonPath, data.name));
            UIManager.Instance.GetStorage().Set(LoadItemArrayFromJson(StringManager.ItemJsonPath, StringManager.StorageName));
            UIManager.Instance.GetSkill().Set(player.skills);
        }
        else
        {
            CameraSetActive(false);
        }
    }
    private void CameraSetActive(bool active)
    {
        playerCamera.gameObject.SetActive(active);
        virtualCamera.gameObject.SetActive(active);
    }

    #region DataManagement
    public void SavePlayerDataToJson(string jsonPath, string characterName, PlayerData data)
    {

        string jsonData = JsonUtility.ToJson(data, true);

        string path = Path.Combine(jsonPath, $"{characterName}.json");

        File.WriteAllText(path, jsonData);
    }

    public PlayerData LoadPlayerDataFromJson(string jsonPath, string characterName)
    {

        string path = Path.Combine(jsonPath, $"{characterName}.json");
        if (File.Exists(path))
        {

            string jsonData = File.ReadAllText(path);

            return JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Application.Quit();
            return null;
        }
    }

    public void SaveItemArrayToJson(string jsonPath, string itemArrayName, SlotItem data)
    {
        slot = data;

        string jsonData = JsonUtility.ToJson(slot, true);

        string path = Path.Combine(jsonPath, $"{itemArrayName}.json");

        File.WriteAllText(path, jsonData);
    }

    public SlotItem LoadItemArrayFromJson(string jsonPath, string itemArrayName)
    {

        string path = Path.Combine(jsonPath, $"{itemArrayName}.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            return JsonUtility.FromJson<SlotItem>(jsonData);
        }
        return null;
    }
    public bool DeleteCharacter(string jsonPath, string characterName)
    {
        string path = Path.Combine(jsonPath, $"{characterName}.json");
        bool result = File.Exists(path);
        if (result)
        {
            File.Delete(path);
        }
        return result;
    }
    void PlayerPosSave()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 4)
        {
            return;
        }
        data.currentPlayerPos = Myplayer.transform.position;
    }
    public void Save()
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneType.Start && SceneManager.GetActiveScene().buildIndex != (int)SceneType.Loading)
        {
            data.scene = (SceneType)SceneManager.GetActiveScene().buildIndex;
            PlayerPosSave();
            data.currentPlayerRot = Myplayer.transform.rotation;
            SaveItemArrayToJson(StringManager.ItemJsonPath, data.name, UIManager.Instance.GetInventory().Get());
            SaveItemArrayToJson(StringManager.ItemJsonPath, StringManager.StorageName, UIManager.Instance.GetStorage().Get());
        }
        SavePlayerDataToJson(StringManager.JsonPath, data.name, data);
    }
    #endregion DataManagement

    #region GamePlay
    public void GameStart()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneLoadManager.LoadScene((int)data.scene);
    }

    public void HomeButton()
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneType.Start)
        {
            SceneLoadManager.LoadScene((int)SceneType.Start);
            Save();
            player = null;
            data = null;
            Myplayer = null;
        }
    }
    public void FinishPopUp()
    {
        UIManager.Instance.ActivePopUpUI("게임 종료", "정말 게임을 종료 하시겠습니까?", Finish);
    }

    void Finish()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
        Save();
    }
    #endregion GamePlay
}
