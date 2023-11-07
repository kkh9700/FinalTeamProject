using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public int slotID;
    public bool isContain;
    public Item item;
    private InventoryItem inventoryItem;

    private void Start()
    {
        inventoryItem = GetComponentInChildren<InventoryItem>();
    }
}