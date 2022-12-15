using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySlots 
{

    [SerializeField] private InventoryData itemdata;
    [SerializeField] private int stackSize;

    public InventoryData ItemData => ItemData;

    public int StackSize => stackSize;

    public InventorySlots(InventoryData source, int amount)
    {
        itemdata = source;
        stackSize = amount;

    }

    public InventorySlots()
    {
        ClearSlot();
    }


    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = ItemData.MaxStackSize - stackSize;

        return RoomLeftInStack(amountToAdd);

    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (stackSize + amountToAdd <= itemdata.MaxStackSize) return true;
        else return false;

    }


    public void ClearSlot()
    {
        itemdata = null;
        stackSize = -1;

    }

    public void UpdateInventorySlot(InventoryData data, int amount)
    {
        itemdata = data;
        stackSize = amount;
    }


    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {

        stackSize -= amount;
    }


}
