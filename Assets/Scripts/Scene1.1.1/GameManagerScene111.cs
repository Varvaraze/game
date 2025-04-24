using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManagerScene111 : MonoBehaviour
{
    public static GameManagerScene111 Instance;
    public string currentObjective = "Найдите 3 важных предмета";
    public List<string> inventory = new List<string>();
    public UIManager111 ui;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ui = FindAnyObjectByType<UIManager111>();
        if (ui != null)
        {
            ui.UpdateObjective(currentObjective);
            ui.UpdateInventory(inventory);
        }
    }

    public void AddItemToInventory(string item)
    {
        Debug.Log("Пытаемся добавить предмет: " + item);

        if (!inventory.Contains(item) && inventory.Count < 3)
        {
            inventory.Add(item);
            Debug.Log("Добавлен предмет: " + item);
            Debug.Log("Всего предметов: " + inventory.Count);
            ui?.UpdateInventory(inventory);

            if (inventory.Count == 3)
            {
                Debug.Log("Все 3 предмета собраны. Переход к следующей сцене.");
                UIManager111.Instance.FadeToBlackAndLoadScene("CutScene"); // Убедись, что сцена с таким именем есть!
            }
        }
        else
        {
            Debug.Log("Предмет уже в инвентаре или достигнут лимит предметов.");
        }
    }

}
