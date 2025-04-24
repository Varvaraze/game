using UnityEngine;
using System.Collections.Generic;

public class InventoryManager111 : MonoBehaviour
{
    public static InventoryManager111 Instance;

    private List<string> items = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void AddItem(string item)
    {
        if (items.Count < 3 && !items.Contains(item))
        {
            items.Add(item);
            UIManager111.Instance.UpdateInventory(GameManagerScene111.Instance.inventory);
            UIManager111.Instance.ShowMessage($"Вы подобрали: {item}");

            if (items.Count == 3)
            {
                UIManager111.Instance.UpdateObjective("Вы собрали всё необходимое!");
                UIManager111.Instance.FadeToBlackAndLoadScene("CutScene"); // ← замени на нужную сцену
            }
        }
        else
        {
            UIManager111.Instance.ShowMessage("Этот предмет уже есть или инвентарь полон.");
        }
    }

    public List<string> GetItems()
    {
        return new List<string>(items);
    }

    public bool HasItem(string item)
    {
        return items.Contains(item);
    }
}
