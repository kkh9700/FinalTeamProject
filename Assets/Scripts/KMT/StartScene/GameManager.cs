using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;
    public static GameManager s_instance;
    public UIManager uiManager;
    public PlayerData player;
    public GameObject Myplayer;
    WaitForSecondsRealtime wait;
    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(this);
        }
        wait = new WaitForSecondsRealtime(20f);
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public IEnumerator RealTimeSave()
    {
        while (true)
        {
            if (SceneManager.GetActiveScene().buildIndex != (int)SceneType.Start)
            {
                Save();
            }
            yield return wait;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (player.baseObject != null && scene.buildIndex != (int)SceneType.Start && scene.buildIndex != (int)SceneType.Loading)
        {
            Myplayer = Instantiate<GameObject>(player.baseObject);
            Myplayer.AddComponent<PlayerCondition>().playerData = player;
            Myplayer.transform.position = player.currentPlayerPos;
            uiManager.gameObject.SetActive(true);
            uiManager.GetInventory().Set(LoadItemArrayFromJson(StringManager.ItemJsonPath, player.name));
            uiManager.GetStorage().Set(LoadItemArrayFromJson(StringManager.ItemJsonPath, StringManager.StorageName));
        }
    }
    public void Finish()
    {
        Application.Quit();
    }
    public void SavePlayerDataToJson(string jsonPath, string characterName, PlayerData data)
    {
        // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다  
        string jsonData = JsonUtility.ToJson(data, true);
        // 데이터를 저장할 경로 지정
        string path = Path.Combine(jsonPath, $"{characterName}.json");
        // 파일 생성 및 저장
        File.WriteAllText(path, jsonData);
    }
    public PlayerData LoadPlayerDataFromJson(string jsonPath, string characterName)
    {
        // 데이터를 불러올 경로 지정
        string path = Path.Combine(jsonPath, $"{characterName}.json");
        if(File.Exists(path))
        {
            // 파일의 텍스트를 string으로 저장
            string jsonData = File.ReadAllText(path);
            // 이 Json데이터를 역직렬화하여 playerData에 넣어줌
            return JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Application.Quit();
            return null;
        }
    }
    public void SaveItemArrayToJson(string jsonPath, string itemArrayName, Item[] data)
    {
        // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다  
        string jsonData = JsonUtility.ToJson(data, true);
        Debug.Log("발동1");
        // 데이터를 저장할 경로 지정
        string path = Path.Combine(jsonPath, $"{itemArrayName}.json");
        // 파일 생성 및 저장
        File.WriteAllText(path, jsonData);
    }
    public Item[] LoadItemArrayFromJson(string jsonPath, string itemArrayName)
    {
        // 데이터를 불러올 경로 지정
        string path = Path.Combine(jsonPath, $"{itemArrayName}.json");
        if(File.Exists(path))
        {
            Debug.Log("발동");
            string jsonData = File.ReadAllText(path);
            return JsonUtility.FromJson<Item[]>(jsonData);
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
    public void HomeButton()
    {
        if(SceneManager.GetActiveScene().buildIndex != (int)SceneType.Start)
        {
            SceneLoadManager.LoadScene((int)SceneType.Start);
            Save();
            StopCoroutine(RealTimeSave());
            player = null;
            Myplayer = null;
        }
    }
    public void Save()
    {
        if(SceneManager.GetActiveScene().buildIndex != (int)SceneType.Start && SceneManager.GetActiveScene().buildIndex != (int)SceneType.Loading)
        {
            player.scene = (SceneType)SceneManager.GetActiveScene().buildIndex;
            player.currentPlayerPos = Myplayer.transform.position;
            SaveItemArrayToJson(StringManager.ItemJsonPath, player.name, uiManager.GetInventory().Get());
            SaveItemArrayToJson(StringManager.ItemJsonPath, StringManager.StorageName, uiManager.GetStorage().Get());
        }
        SavePlayerDataToJson(StringManager.JsonPath, player.name, player);
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void OnSettingCanvasInputEnable()
    {
        
    }
    private void ActiveSettingCanvas(InputAction.CallbackContext context)
    {
        settingCanvas.SetActive(!settingCanvas.activeSelf);
    }
}
