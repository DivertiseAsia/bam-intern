using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum WeaponClass
{
    sword,
    bow,
    axe
}

public class Weapon : Item
{
    public WeaponTemplateScriptableObject _itemTemplate;
    public WeaponClass weaponClass = WeaponClass.sword;
    public void attackSkill()
    {
        Debug.Log("I attacked with: ");
    }

    public override void SetTemplate()
    {
        base.itemTemplate = itemTemplate;
        base.name = _itemTemplate.name;
        base.description = _itemTemplate.description;
        base.rarity = _itemTemplate.rarity;
        base.itemType = _itemTemplate.itemType;
        //base.sprite.sprite = itemTemplate.itemIcon;
        weaponClass = _itemTemplate.weaponClass;
    }
    static int count = 0;

    [MenuItem("Assets/Create/Project Exclusive/Item/Weapon")]
    public static void CreateWeaponItem()
    {
        var path = "Assets/Script/ScriptableObject";
        WeaponTemplateScriptableObject template = ScriptableObject.CreateInstance<WeaponTemplateScriptableObject>();
        template.itemType = ItemType.weapon;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Weapon>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewWeapon" + count + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Weapon>().itemTemplate = (WeaponTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + count + ".asset", typeof(WeaponTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewWeapon" + count + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + count + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;

    }

    public static void CreateWeaponItem(string itemName, string description, Sprite sprite, Rarity rarity, WeaponClass weaponClass)
    {
        var path = "Assets/Script/ScriptableObject/";
        WeaponTemplateScriptableObject template = ScriptableObject.CreateInstance<WeaponTemplateScriptableObject>();
        template.itemType = ItemType.weapon;
        template.itemType = ItemType.head;
        template.name = itemName;
        template.description = description;
        template.itemIcon = sprite;
        template.rarity = rarity;
        template.weaponClass = weaponClass;
        
        GameObject tObject = new GameObject();
        tObject.AddComponent<Weapon>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + itemName + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Weapon>()._itemTemplate = (WeaponTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + count + ".asset", typeof(WeaponTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + itemName + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;

    }
}
