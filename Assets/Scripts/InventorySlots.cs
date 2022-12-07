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


    public void ClearSlot()
    {
        itemdata = null;
        stackSize = -1;

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
