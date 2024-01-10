using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    common,
    rare,
    epic,
    legendary
}

public enum ItemType
{
    head,
    body,
    weapon
}

public class Item : MonoBehaviour
{
    [SerializeField] ItemTemplateScriptableObject itemTemplate;

    [SerializeField] private new string name = "ItemName";
    [SerializeField] private string description;
    [SerializeField] private Rarity rarity = Rarity.common;
    [SerializeField] protected ItemType itemType;

    SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    public string GetDescription()
    {
        return description;
    }
    public int GetRarity()
    {
        return (int)itemTemplate.rarity;
    }

    public Sprite GetItemIcon()
    {
        return itemTemplate.itemIcon;
    }

    [ExecuteInEditMode]

    public void Start()
    {
        if (itemTemplate == null) return;
        name = itemTemplate.name;
        description = itemTemplate.description;
        rarity = itemTemplate.rarity;
        itemType = itemTemplate.itemType;
        sprite.sprite = itemTemplate.itemIcon;
    }
}
