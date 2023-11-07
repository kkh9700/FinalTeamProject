using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] private Transform slots;
    private ItemSlot[] inventorySlots;
    private EquipSlot[] equipSlots;
    private int gold = 3000000;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold += value;

            text.text = string.Format("{0:#,###}", gold);
        }
    }
    public int limit;
    public TMP_Text text;

    private void Awake()
    {
        inventorySlots = new ItemSlot[30];
        text.text = string.Format("{0:#,###}", gold);

        for (int i = 0; i < 30; i++)
        {
            GameObject slot = Resources.Load<GameObject>("KH/Prefabs/UI/UI_ItemSlot");
            slot = Instantiate(slot, slots);
            slot.name = "InventorySlot" + i;
            inventorySlots[i] = slot.AddComponent<InventorySlot>();
            inventorySlots[i].slotID = i;
            inventorySlots[i].Clear();
        }
    }

    public void SetLimit(int limit)
    {
        this.limit = limit;
    }

    public bool AddItem(Item item)
    {
        if (limit == 0)
            return false;

        if (item.type == ItemType.Gold)
        {
            IStackable stackableItem = (IStackable)item;
            gold += stackableItem.Get();
        }
        else if (item is IStackable)
        {
            IStackable stackableItem = (IStackable)item;

            int index = FindItemIndex(item);

            if (index == -1)
            {
                AddItem(FindIndex(), item);
            }
            else
            {
                inventorySlots[index].AddItem(stackableItem.Get());
            }
        }
        else
        {
            AddItem(FindIndex(), item);
        }

        return true;
    }

    public void AddItem(int index, Item item)
    {
        if (item != null)
            limit--;
        inventorySlots[index].SetItem(item);
    }

    private int FindIndex()
    {
        for (int i = 0; i < 30; i++)
        {
            if (inventorySlots[i].GetItem() == null)
            {
                return i;
            }
        }

        return -1;
    }

    private int FindItemIndex(Item item)
    {
        for (int i = 0; i < 30; i++)
        {
            if (item.itemName.Equals(inventorySlots[i].GetItem().itemName))
                return i;
        }

        return -1;
    }

    public void SwapItems(int slotA, int slotB)
    {
        // 슬롯 A와 슬롯 B의 아이템 위치를 바꿈
        Item item = inventorySlots[slotA].GetItem();
        inventorySlots[slotA].SetItem(inventorySlots[slotB].GetItem());
        inventorySlots[slotB].SetItem(item);
    }

    public void Equip(int slotA)
    {
        Item item = inventorySlots[slotA].GetItem();

        EquipSlot equipSlot = equipSlots[(int)item.type];

        AddItem(slotA, equipSlot.GetItem());

        equipSlot.Equip((EquipItem)item);
    }

    public void UnEquip(int slotA, ItemType type)
    {
        EquipSlot equipSlot = equipSlots[(int)type];
        Item item = inventorySlots[slotA].GetItem();
        if (item != null)
        {
            if (item is EquipItem)
            {
                EquipItem equipItem = (EquipItem)item;

                if (equipItem.type == type)
                {
                    AddItem(slotA, equipSlot.GetItem());
                    equipSlot.UnEquip();
                    equipSlot.Equip(equipItem);

                    return;
                }
            }
            AddItem(equipSlot.GetItem());
            equipSlot.UnEquip();
        }
        else
        {
            AddItem(slotA, equipSlot.GetItem());
            equipSlot.UnEquip();
        }
    }

    public Item[] Get()
    {
        Item[] items = new Item[37];

        for (int i = 0; i < 7; i++)
        {
            items[i] = equipSlots[i].GetItem();
        }

        for (int i = 0; i < 30; i++)
        {
            items[i + 7] = inventorySlots[i].GetItem();
        }

        return items;
    }

    public void Set(Item[] items)
    {
        for (int i = 0; i < 37; i++)
        {
            if (i < 7)
            {
                equipSlots[i].SetItem(items[i]);
            }
            else
            {
                inventorySlots[i - 7].SetItem(items[i]);
            }
        }
    }
}
