using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]

public class InventorySystem
{

    [SerializeField] private List<InventorySlots> inventorySlots;

    public List<InventorySlots> InventorySlots => inventorySlots;

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlots> OnInventorySlotsChanged;


    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlots>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlots());
        }

    }

    public bool AddToInvemtory(InventoryData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlots> invslot))

            foreach (var slot in invslot)

            {
                if (slot.RoomLeftInStack(amountToAdd))


                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotsChanged?.Invoke(slot);
                    return true;

                }
            }


        if (HasFreeSlot(out InventorySlots freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotsChanged?.Invoke(freeSlot);
            return true;

        }

        return false;
    }

    public bool ContainsItem(InventoryData itemToAdd, out List<InventorySlots> invSlot)
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();

        return invSlot == null ? false : true;

    }

    public bool HasFreeSlot(out InventorySlots freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;

    }
}
