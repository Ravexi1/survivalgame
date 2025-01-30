using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;  // ���� ���������
    public Transform slotContainer;    // ��������� ������
    public GameObject slotPrefab;      // ������ �����

    private InventorySystem inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>(); // ������� ������� ���������
        inventoryPanel.SetActive(false); // �������� ��������� ��� ������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // ������� "I" ���������/��������� ���������
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        // ������� ������ �����
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        // ������ ������ 15 ������ ��������
        for (int i = 0; i < Mathf.Min(inventory.inventory.Count, 15); i++)
        {
            Item item = inventory.inventory[i];
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
            slot.transform.GetChild(0).GetComponent<Text>().text = item.quantity.ToString();
        }

        // ������ ����� �����
        foreach (Item item in inventory.inventory)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);
            slot.GetComponent<Image>().sprite = item.icon;
            slot.transform.GetChild(0).GetComponent<Text>().text = item.quantity.ToString();
        }
    }
}
