using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Rarity
{
    common,
    rare,
    epic,
    legendary,
    none
}

public enum ItemType
{
    head,
    body,
    weapon
}

public abstract class Item : MonoBehaviour
{
    [HideInInspector] public ItemTemplateScriptableObject itemTemplate;
    [SerializeField] protected new string name = "ItemName";
    [SerializeField] protected string description;
    [SerializeField] protected Rarity rarity = Rarity.common;
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

    public ItemTemplateScriptableObject GetTemplate()
    {
        return itemTemplate;
    }
    public abstract void SetTemplate();

    [ExecuteInEditMode]

    public void Start()
    {
        if (itemTemplate == null) return;
        SetTemplate();
    }
}