using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item;
    private InventorySystem inventory;

    public Button button; // ������ �� ������

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
        button.onClick.AddListener(OnClick); // ��������� ���������� ������� �� ������
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        GetComponent<Image>().sprite = item.icon;
        transform.GetChild(0).GetComponent<Text>().text = item.quantity.ToString();
    }

    public void OnClick()
    {
        if (item != null)
        {
            inventory.RemoveItem(item); // ������� ������� �� ���������
            Destroy(gameObject); // ������� ���� �� UI
        }
    }
}
