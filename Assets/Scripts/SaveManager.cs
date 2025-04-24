using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]
public class SaveData
{
    public string sceneName;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    private string savePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/save.json";

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Menu") // 💥 не сохраняем главное меню
        {
            SaveCurrentScene();
        }
    }

    public void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene != "Menu")
        {
            SaveGame(currentScene);
        }
    }

    public void SaveGame(string sceneName)
    {
        SaveData data = new SaveData();
        data.sceneName = sceneName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Сцена сохранена: " + sceneName);

        MainMenuUI menu = Object.FindFirstObjectByType<MainMenuUI>();
        if (menu != null)
        {
            menu.UpdateContinueButtonVisibility();
        }
    }

    public bool HasSave()
    {
        if (!File.Exists(savePath)) return false;

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // 💥 проверяем, что сцена существует и не MainMenu
        return !string.IsNullOrEmpty(data.sceneName) && data.sceneName != "Menu";
    }

    public string GetSavedScene()
    {
        if (!File.Exists(savePath)) return null;

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data.sceneName;
    }
}
