using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;  // Окно инвентаря
    public Transform slotContainer;    // Контейнер слотов
    public GameObject slotPrefab;      // Префаб слота

    private InventorySystem inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>(); // Находим систему инвентаря
        inventoryPanel.SetActive(false); // Скрываем инвентарь при старте
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // Клавиша "I" открывает/закрывает инвентарь
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        // Удаляем старые слоты
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        // Создаём только 15 слотов максимум
        for (int i = 0; i < Mathf.Min(inventory.inventory.Count, 15); i++)
        {
            Item item = inventory.inventory[i];
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
            slot.transform.GetChild(0).GetComponent<Text>().text = item.quantity.ToString();
        }

        // Создаём новые слоты
        foreach (Item item in inventory.inventory)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
            slot.transform.GetChild(0).GetComponent<Text>().text = item.quantity.ToString();
        }
    }
}
