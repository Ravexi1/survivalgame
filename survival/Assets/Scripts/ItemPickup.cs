using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // ����������� �������, ������� ����� �����������
    private bool playerInRange = false; // ��� ��������, ����� �� �����

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // ��������� ������� ������� 'E'
        {
            InventorySystem inventory = FindFirstObjectByType<InventorySystem>();
            if (inventory != null)
            {
                inventory.AddItem(item); // ��������� ������� � ���������
                Destroy(gameObject); // ������� ������� � �����
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ��������, ���� ����� � �������
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ��������, ���� ����� ������� ������
        {
            playerInRange = false;
        }
    }
}