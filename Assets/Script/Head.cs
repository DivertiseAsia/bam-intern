using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Head : Item
{
    float defATK;
    static int count = 0;

    [MenuItem("Assets/Create/Project Exclusive/Item/Head")]
    public static void CreateBodyItem()
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
}
