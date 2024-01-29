using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.IO;

public class CurrencyFactory : EditorWindow
{
    public int id;
    public string currencyName;
    public int maxCapa;
    public CurrenciesList currencyList;
    public Sprite currencyIcon;

    [MenuItem("Window/Currency Factory")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<CurrencyFactory>("Currency Factory");
    }

    public void OnGUI()
    {
        var path = "Assets/Currency";
        GameObject list = (GameObject)AssetDatabase.LoadAssetAtPath(path + "/Currency List.prefab", typeof(GameObject));
        EditorGUILayout.PrefixLabel("Currency List");
        currencyList = (CurrenciesList)EditorGUILayout.ObjectField(list.GetComponent<CurrenciesList>(), typeof(CurrenciesList), true);
        EditorGUILayout.PrefixLabel("Currency Detail");
        id = EditorGUILayout.IntField("ID" , currencyList.currencyList.Count);
        currencyName = EditorGUILayout.TextField("Name", currencyName);
        maxCapa = EditorGUILayout.IntField("Max Capacity", maxCapa);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Currrency Icon");
        currencyIcon = (Sprite)EditorGUILayout.ObjectField(currencyIcon, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add/Edit Currency"))
        {
            CreateNewCurrency(id, currencyName, maxCapa, currencyIcon, currencyList);
            EditorUtility.SetDirty(currencyList);
        }


    }

    public static void CreateNewCurrency(int _id, string _name, int _maxCapa, Sprite _icon, CurrenciesList _list)
    {
        Debug.Log("Data recieve: " + _id + _name + _maxCapa + _icon);
        Currency _c = new Currency(_name, _id, _maxCapa, _icon);
        File.WriteAllText(Application.dataPath + "/Currency/" + _name + ".JSON", _c.ExportToJSON());
        _list.currencyList.Add(_c);
        PrefabUtility.RecordPrefabInstancePropertyModifications(_list);
        EditorUtility.SetDirty(_list);
        Debug.Log("Object created: " + _c + ". Type: " + _c.GetType());
    }

}
