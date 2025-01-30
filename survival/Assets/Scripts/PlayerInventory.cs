using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private InventorySystem inventory;

    void Start()
    {
        inventory = GetComponent<InventorySystem>();
        FindFirstObjectByType<InventoryUI>().UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Подбираем предмет
        {
            // Тут можно добавить логику поиска предметов на земле
            Item newItem = new Item { itemName = "Зелье здоровья", quantity = 1 };
            inventory.AddItem(newItem);
        }

        if (Input.GetKeyDown(KeyCode.I)) // Открываем/закрываем инвентарь
        {
            Debug.Log("Инвентарь открыт!");
        }
    }
}
