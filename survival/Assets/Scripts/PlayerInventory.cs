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
        if (Input.GetKeyDown(KeyCode.E)) // ��������� �������
        {
            // ��� ����� �������� ������ ������ ��������� �� �����
            Item newItem = new Item { itemName = "����� ��������", quantity = 1 };
            inventory.AddItem(newItem);
        }

        if (Input.GetKeyDown(KeyCode.I)) // ���������/��������� ���������
        {
            Debug.Log("��������� ������!");
        }
    }
}
