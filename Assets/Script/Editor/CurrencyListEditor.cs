using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CurrenciesList))]
public class CurrenciesListEditor : Editor
{
    CurrenciesList currenciesList;

    public void OnEnable()
    {
        currenciesList = (CurrenciesList)target;
    }

    public override void OnInspectorGUI()
    {
        var list = currenciesList.currencyList;
        int newCount = Mathf.Max(0, EditorGUILayout.IntField("size", list.Count));
        EditorGUILayout.BeginFadeGroup(1);
        for (int i = 0; i < list.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(list[i].currencyID + "", GUIStyle.none);
            EditorGUILayout.LabelField("", list[i].GetName());
            if (GUILayout.Button("Delete", GUILayout.Width(49f)))
            {
                currenciesList.RemoveCurrency(list[i].currencyID);
                EditorUtility.SetDirty(currenciesList);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFadeGroup();

        if (GUILayout.Button("Hard Reset List"))
        {
            currenciesList.HardResetList();
            EditorUtility.SetDirty(currenciesList);
        }
    }
}