using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Body : Item
{
    float atkPoint;
    static int count = 0;

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
}

