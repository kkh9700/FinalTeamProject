using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StorageItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerDownHandler
{
    public int slotID;
    private GameObject itemClone;
    private Canvas canvas;
    private RectTransform rect;
    private RawImage icon;
    private Item item;
    private TMP_Text quantity;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        icon = GetComponentInChildren<RawImage>();
        quantity = GetComponentInChildren<TMP_Text>();
        item = null;
    }

    public void SetItem(Item item)
    {
        if (gameObject.TryGetComponent<Item>(out Item tmp))
        {
            Destroy(tmp);
        }

        if (item.type == ItemType.Resources || item.type == ItemType.Gold)
        {
            this.item = gameObject.AddComponent<ResourceItem>();
        }
        else if (item.type == ItemType.Consumes)
        {
            this.item = gameObject.AddComponent<UseItem>();
        }
        else
        {
            this.item = gameObject.AddComponent<EquipItem>();
        }

        this.item.Set(item);

        icon.texture = item.texture;

        if (item is IStackable)
        {
            IStackable stackableItem = (IStackable)item;
            quantity.text = stackableItem.Get().ToString();
        }
        else
        {
            quantity.text = string.Empty;
        }

        SetAlpha(1);
    }

    public void AddItem(int count)
    {
        if (item is IStackable)
        {
            IStackable stackableItem = (IStackable)item;
            stackableItem.Add(count);
            quantity.text = stackableItem.Get().ToString();
        }
    }

    private void SetAlpha(float a)
    {
        Color color = icon.color;
        color.a = a;
        icon.color = color;
    }

    private bool isInItem()
    {
        return TryGetComponent<Item>(out Item item);
    }

    public void Clear()
    {
        SetAlpha(0);
        quantity.text = string.Empty;
        Destroy(item);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isInItem())
            return;
        itemClone = Instantiate(gameObject, canvas.GetComponent<Transform>());
        rect = itemClone.GetComponent<RectTransform>();

        Vector2 mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        rect.anchoredPosition = mousePosition;

        RawImage image = itemClone.GetComponentInChildren<RawImage>();
        Color color = image.color;
        color.a = .8f;
        image.color = color;

        TMP_Text text = itemClone.GetComponentInChildren<TMP_Text>();
        color = text.color;
        color.a = .8f;
        text.color = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isInItem())
            return;
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isInItem())
            return;
        Destroy(itemClone);
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInItem() && eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}