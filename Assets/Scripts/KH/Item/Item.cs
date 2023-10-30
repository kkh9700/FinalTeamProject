using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public Texture2D texture;
    public Rank rank;
    public ItemType type;
    public GameObject prefab;

    public void Set(ItemSO itemSO)
    {
        itemName = itemSO.itemName;
        description = itemSO.description;
        texture = itemSO.texture;
        rank = itemSO.rank;
        type = itemSO.type;
        prefab = itemSO.prefab;
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }
}
