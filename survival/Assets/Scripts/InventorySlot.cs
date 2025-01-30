using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item;
    private InventorySystem inventory;

    public Button button; // Ссылка на кнопку

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
        button.onClick.AddListener(OnClick); // Добавляем обработчик события на кнопку
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
            inventory.RemoveItem(item); // Удаляем предмет из инвентаря
            Destroy(gameObject); // Удаляем слот из UI
        }
    }
}
