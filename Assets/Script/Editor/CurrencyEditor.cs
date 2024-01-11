using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/*
[CustomEditor(typeof(CurrencyScriptableObject))]
public class CurrencyEditor : Editor
{
    CurrencyScriptableObject currency;

    public void OnEnable()
    {
        currency = (CurrencyScriptableObject)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PrefixLabel("Currency Detail");
        EditorGUILayout.LabelField("ID", (CurrenciesList.getCount()) + "");
        currency.currencyName = EditorGUILayout.TextField("Name", currency.currencyName);
        currency.maxCapa = EditorGUILayout.IntField("Max Capacity", currency.maxCapa);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Currrency Icon");
        currency.currencyIcon = (Sprite)EditorGUILayout.ObjectField(currency.currencyIcon, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add/Edit Currency")) AddOrEditCurrency();

        EditorUtility.SetDirty(currency);

        
    }
    private void AddOrEditCurrency()
    {
        Currency _c = CurrenciesList.FindCurrency(currency.currencyName);
        if (_c == null)
        {
            CurrenciesList.AddCurrency(new Currency(currency));
            return;
        }
        _c.Edit(currency);
    }
}
*/