
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{


    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlots assignedInventorySlots;

    private Button button;

    public InventorySlots AssignedInventorySlot => assignedInventorySlot;


    private void Awake()
    {
        ClearSlot();

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void Init(InventorySlots slot)
    {
        AssignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlots slot)
    {

    }

    public void ClearSlot()
    {
        assignedInventorySlots?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";

    }


}
