using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

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
            Currency.CreateNewCurrency(id, currencyName, maxCapa, currencyIcon, currencyList);
            EditorUtility.SetDirty(currencyList);
        }


    }
}
