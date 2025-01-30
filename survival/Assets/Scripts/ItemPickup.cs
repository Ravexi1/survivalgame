using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // Присваиваем предмет, который будет подбираться
    private bool playerInRange = false; // Для проверки, рядом ли игрок

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // Проверяем нажатие клавиши 'E'
        {
            InventorySystem inventory = FindFirstObjectByType<InventorySystem>();
            if (inventory != null)
            {
                inventory.AddItem(item); // Добавляем предмет в инвентарь
                Destroy(gameObject); // Удаляем предмет с земли
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверка, если игрок в радиусе
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Проверка, если игрок покинул радиус
        {
            playerInRange = false;
        }
    }
}