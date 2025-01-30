using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public int maxSlots = 15;

    public void AddItem(Item newItem)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName == newItem.itemName)
            {
                item.quantity += newItem.quantity; // Увеличиваем количество
                Debug.Log("Увеличено количество предмета: " + newItem.itemName);
                return; // Выход из метода, если предмет найден
            }
        }

        if (inventory.Count < maxSlots)
        {
            inventory.Add(newItem);
            Debug.Log("Добавлен предмет: " + newItem.itemName);
        }
        else
        {
            Debug.Log("Инвентарь полон!");
        }
    }

    public void RemoveItem(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log("Удалён предмет: " + item.itemName);
            FindFirstObjectByType<InventoryUI>().UpdateUI(); // Обновляем UI после удаления
        }
    }
}
