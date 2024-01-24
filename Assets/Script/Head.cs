using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Head : Item
{
    public HeadTemplateScriptableObject _itemTemplate;
    float defATK;
    static int count = 0;

    public override void SetTemplate()
    {
        base.itemTemplate = itemTemplate;
        base.name = _itemTemplate.name;
        base.description = _itemTemplate.description;
        base.rarity = _itemTemplate.rarity;
        base.itemType = _itemTemplate.itemType;
        //base.sprite.sprite = itemTemplate.itemIcon;
        defATK = _itemTemplate.defPoint;
    }

    [MenuItem("Assets/Create/Project Exclusive/Item/Head")]
    public static void CreateHeadItem()
    {
        var path = "Assets/Script/ScriptableObject";
        HeadTemplateScriptableObject template = ScriptableObject.CreateInstance<HeadTemplateScriptableObject>();
        template.itemType = ItemType.head;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Head>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewHead" + count + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Head>().itemTemplate = (HeadTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewHead" + count + ".asset", typeof(HeadTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewHead" + count + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewHead" + count + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;
    }

    public static void CreateHeadItem(string itemName, string description, Sprite sprite, Rarity rarity, int DEFpoint)
    {
        var path = "Assets/Script/ScriptableObject/";
        HeadTemplateScriptableObject template = ScriptableObject.CreateInstance<HeadTemplateScriptableObject>();
        template.itemType = ItemType.head;
        template.name = itemName;
        template.description = description;
        template.itemIcon = sprite;
        template.rarity = rarity;
        template.defPoint = DEFpoint;

        GameObject tObject = new GameObject();
        tObject.AddComponent<Head>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + itemName + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Head>()._itemTemplate = (HeadTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".asset", typeof(HeadTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + itemName + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        count++;
    }
}
