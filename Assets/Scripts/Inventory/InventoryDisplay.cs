
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour

{

    [SerializeField] MoveItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlots> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;

    public Dictionary<InventorySlot_UI, InventorySlots> SlotDictionary => slotDictionary;

    protected virtual void Start()

    {


    }

    public abstract void AssignSlot(InventorySystem invToDisplay);


    protected virtual void UpdateSlot(InventorySlots updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot)

            {

                slot.Key.UpdateUISlot(updatedSlot);

            }
        }

    }

 public void SlotClicked(InventorySlot_UI clickedSlot)

    {

    }

}
