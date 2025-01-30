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
                item.quantity += newItem.quantity; // ����������� ����������
                Debug.Log("��������� ���������� ��������: " + newItem.itemName);
                return; // ����� �� ������, ���� ������� ������
            }
        }

        if (inventory.Count < maxSlots)
        {
            inventory.Add(newItem);
            Debug.Log("�������� �������: " + newItem.itemName);
        }
        else
        {
            Debug.Log("��������� �����!");
        }
    }

    public void RemoveItem(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log("����� �������: " + item.itemName);
            FindFirstObjectByType<InventoryUI>().UpdateUI(); // ��������� UI ����� ��������
        }
    }
}
