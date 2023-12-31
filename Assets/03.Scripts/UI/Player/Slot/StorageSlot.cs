using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageSlot : ItemSlot, IDropHandler, IPointerDownHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // 드롭 대상의 RectTransform을 얻음
        RectTransform dropTarget = this.transform as RectTransform;

        // 이벤트 데이터를 이용해 드롭 지점에서의 Raycast를 수행
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent<StorageSlot>(out StorageSlot storageSlot))
            {
                if (storageSlot.slotID == slotID)
                    continue;
                UIManager.Instance.GetStorage().SwapItems(slotID, storageSlot.slotID);
                return;
            }

            if (result.gameObject.TryGetComponent<InventorySlot>(out InventorySlot inventorySlot))
            {
                UIManager.Instance.SwapItems(inventorySlot.slotID, slotID);
                return;
            }

            if (result.gameObject.TryGetComponent<EquipSlot>(out EquipSlot equipSlot))
            {
                return;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Item item = GetItem();

        if (item != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (UIManager.Instance.GetInventory().AddItem(item))
            {
                SetItem(null);
            }
        }
    }
}
