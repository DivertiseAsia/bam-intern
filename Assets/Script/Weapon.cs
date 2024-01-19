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
    public WeaponClass weaponClass = WeaponClass.sword;
    public void attackSkill()
    {
        Debug.Log("I attacked with: ");
    }

    static int count = 0;

    [MenuItem("Assets/Create/Project Exclusive/Item/Weapon")]
    public static void CreateBodyItem()
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
}
