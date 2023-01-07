
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{


    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlots;

    private Button button;

    public InventorySlots AssignedInventorySlot => assignedInventorySlots;
    public InventoryDisplay ParentDisplay { get; private set; }


    private void Awake()
    {
        ClearSlot();

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlots slot)
    {
        assignedInventorySlots = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlots slot)
    {
        if (slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;

        }

        else
        {
            ClearSlot();
        }

    }

    public void ClearSlot()
    {
        assignedInventorySlots?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";

    }

    public void OnUISlotClick()

    {
        ParentDisplay?.SlotClicked(this);
    }

}
