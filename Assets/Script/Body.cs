using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Body : Item
{
    public BodyTemplateScriptableObject _itemTemplate;
    float atkPoint;
    static int count = 0;
    public override void SetTemplate()
    {
        base.itemTemplate = itemTemplate;
        base.name = _itemTemplate.name;
        base.description = _itemTemplate.description;
        base.rarity = _itemTemplate.rarity;
        base.itemType = _itemTemplate.itemType;
        //base.sprite.sprite = itemTemplate.itemIcon;
    }

    [MenuItem("Assets/Create/Project Exclusive/Item/Body")]
    public static void CreateBodyItem()
    {
        var path = "Assets/Script/ScriptableObject";
        BodyTemplateScriptableObject template = ScriptableObject.CreateInstance<BodyTemplateScriptableObject>();
        template.itemType = ItemType.body;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Body>();
        
        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewBody" + count + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Body>().itemTemplate = (BodyTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + count + ".asset", typeof(BodyTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewBody" + count + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + count + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;

    }

    public static void CreateBodyItem(string itemName, string description, Sprite sprite, Rarity rarity, int ATKPoint)
    {
        var path = "Assets/Script/ScriptableObject/";
        BodyTemplateScriptableObject template = ScriptableObject.CreateInstance<BodyTemplateScriptableObject>();
        template.itemType = ItemType.body;
        template.itemType = ItemType.weapon;
        template.itemType = ItemType.head;
        template.name = itemName;
        template.description = description;
        template.itemIcon = sprite;
        template.rarity = rarity;
        template.atkPoint = ATKPoint;

        GameObject tObject = new GameObject();
        tObject.AddComponent<Body>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + itemName + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Body>()._itemTemplate = (BodyTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + count + ".asset", typeof(BodyTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + itemName + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;

    }
}

