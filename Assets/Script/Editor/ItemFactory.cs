using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ItemFactory : EditorWindow
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
            if ((int)itemType == (int)ItemType.head) CreateHead(itemName, description, sprite, rarity, DEFPoint);
            else if ((int)itemType == (int)ItemType.body) CreateBody(itemName, description, sprite, rarity, ATKPoint);
            else if ((int)itemType == (int)ItemType.weapon) CreateWeapon(itemName, description, sprite, rarity, weaponClass);
        }
    }

    public static void CreateHead(string itemName, string description, Sprite sprite, Rarity rarity, int DEFpoint)
    {
        CreateHeadItem(itemName, description, sprite, rarity, DEFpoint);
    }
    public static void CreateBody(string itemName, string description, Sprite sprite, Rarity rarity, int ATKpoint)
    {
        CreateBodyItem(itemName, description, sprite, rarity, ATKpoint);
    }
    public static void CreateWeapon(string itemName, string description, Sprite sprite, Rarity rarity, WeaponClass weaponClass)
    {
        CreateWeaponItem(itemName, description, sprite, rarity, weaponClass);
    }

    static int headcount;

    [MenuItem("Assets/Create/Project Exclusive/Item/Head")]
    public static void CreateHeadItem()
    {
        var path = "Assets/Script/ScriptableObject";
        HeadTemplateScriptableObject template = ScriptableObject.CreateInstance<HeadTemplateScriptableObject>();
        template.itemType = ItemType.head;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Head>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewHead" + headcount + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Head>().itemTemplate = (HeadTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewHead" + headcount + ".asset", typeof(HeadTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewHead" + headcount + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewHead" + headcount + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        headcount++;
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
        headcount++;
    }

    static int weaponcount = 0;

    [MenuItem("Assets/Create/Project Exclusive/Item/Weapon")]
    public static void CreateWeaponItem()
    {
        var path = "Assets/Script/ScriptableObject";
        WeaponTemplateScriptableObject template = ScriptableObject.CreateInstance<WeaponTemplateScriptableObject>();
        template.itemType = ItemType.weapon;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Weapon>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewWeapon" + weaponcount + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Weapon>().itemTemplate = (WeaponTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + weaponcount + ".asset", typeof(WeaponTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewWeapon" + weaponcount + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + weaponcount + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        weaponcount++;

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
        tObject.GetComponent<Weapon>()._itemTemplate = (WeaponTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewWeapon" + weaponcount + ".asset", typeof(WeaponTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + itemName + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        weaponcount++;

    }

    static int bodycount;

    [MenuItem("Assets/Create/Project Exclusive/Item/Body")]
    public static void CreateBodyItem()
    {
        var path = "Assets/Script/ScriptableObject";
        BodyTemplateScriptableObject template = ScriptableObject.CreateInstance<BodyTemplateScriptableObject>();
        template.itemType = ItemType.body;
        GameObject tObject = new GameObject();
        tObject.AddComponent<Body>();

        template.itemRef = tObject;
        AssetDatabase.CreateAsset(template, path + "/NewBody" + bodycount + ".asset");
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = template;
        tObject.GetComponent<Body>().itemTemplate = (BodyTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + bodycount + ".asset", typeof(BodyTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + "/NewBody" + bodycount + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + bodycount + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        bodycount++;

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
        tObject.GetComponent<Body>()._itemTemplate = (BodyTemplateScriptableObject)AssetDatabase.LoadAssetAtPath(path + "/NewBody" + bodycount + ".asset", typeof(BodyTemplateScriptableObject));
        Object prefab = PrefabUtility.SaveAsPrefabAsset(tObject, path + itemName + ".prefab");
        template.itemRef = (GameObject)AssetDatabase.LoadAssetAtPath(path + itemName + ".prefab", typeof(GameObject));
        DestroyImmediate(tObject);
        bodycount++;

    }
}
