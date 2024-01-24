using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

    public static void CreateHead(string itemName, string description, Sprite sprite, Rarity rarity, int DEFpoint)
    {
        Head.CreateHeadItem(itemName, description, sprite, rarity, DEFpoint);
    }
    public static void CreateBody(string itemName, string description, Sprite sprite, Rarity rarity, int ATKpoint)
    {
        Body.CreateBodyItem(itemName, description, sprite, rarity, ATKpoint);
    }
    public static void CreateWeapon(string itemName, string description, Sprite sprite, Rarity rarity, WeaponClass weaponClass)
    {
        Weapon.CreateWeaponItem(itemName, description, sprite, rarity, weaponClass);
    }
}

public class ItemFactory: EditorWindow
{
    public string itemName = "ItemName";
    public string description = "";
    public Sprite sprite;
    public Rarity rarity;
    
    public ItemType itemType;
    public int DEFPoint;
    public int ATKPoint;
    public WeaponClass weaponClass;

    [MenuItem("Window/Item Factory")]
    public static void OpenEditor()
    {
        EditorWindow.GetWindow<ItemFactory>("Item Factory");
    }

    public void OnGUI()
    {
        EditorGUILayout.PrefixLabel("Item Detail");
        itemName = EditorGUILayout.TextField("Item Name", itemName);
        description = EditorGUILayout.TextField("Description", description);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Item Icon");
        sprite = (Sprite)EditorGUILayout.ObjectField(sprite, typeof(Sprite), true);
        EditorGUILayout.EndHorizontal();
        rarity = (Rarity)EditorGUILayout.EnumPopup("Rarity", rarity);

        EditorGUILayout.Space();
        itemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", itemType);

        if ((int)itemType == (int)ItemType.head)
        {
            EditorGUILayout.BeginFadeGroup(1);
            DEFPoint = EditorGUILayout.IntField("DEF Point", DEFPoint);
            EditorGUILayout.EndFadeGroup();
        }
        else if ((int)itemType == (int)ItemType.body)
        {
            EditorGUILayout.BeginFadeGroup(1);
            ATKPoint = EditorGUILayout.IntField("ATK Point", ATKPoint);
            EditorGUILayout.EndFadeGroup();
        }
        else if ((int)itemType == (int)ItemType.weapon)
        {
            weaponClass = (WeaponClass)EditorGUILayout.EnumPopup("Weapon Class", weaponClass);
        }

        if (GUILayout.Button("Create Item"))
        {
            if ((int)itemType == (int)ItemType.head) Item.CreateHead(itemName, description, sprite, rarity, DEFPoint);
            else if ((int)itemType == (int)ItemType.body) Item.CreateBody(itemName, description, sprite, rarity, ATKPoint);
            else if ((int)itemType == (int)ItemType.weapon) Item.CreateWeapon(itemName, description, sprite, rarity, weaponClass);
        }
    }

}