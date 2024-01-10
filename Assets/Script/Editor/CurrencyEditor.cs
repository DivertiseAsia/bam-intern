using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

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
        currency.currencyName = EditorGUILayout.TextField("Name", currency.currencyName);
        if (CurrenciesList.FindCurrency(currency.currencyID))
            currency.currencyID = EditorGUILayout.IntField("ID", currency.currencyID);
        else currency.currencyID = EditorGUILayout.IntField("ID", CurrenciesList.getCount());
        currency.maxCapa = EditorGUILayout.IntField("Max Capacity", currency.maxCapa);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Currrency Icon");
        currency.currencyIcon = (Sprite)EditorGUILayout.ObjectField(currency.currencyIcon, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add/Edit Currency")) AddEditCurrency();

        if (GUILayout.Button("Remove Currency")) RemoveCurrency();


        EditorGUILayout.PrefixLabel("Amount of Currencies: " + CurrenciesList.getCount());
        if (GUILayout.Button("Hard Reset")) DeleteAllCurrency();

        EditorUtility.SetDirty(currency);

        
    }

    private void AddEditCurrency()
    {
        Currency _c = CurrenciesList.FindCurrency(currency.currencyName);
        if (_c == null)
        {
            CurrenciesList.AddCurrency(new Currency(currency));
            return;
        }
        _c.Edit(currency);
    }

    private void RemoveCurrency()
    {
        CurrenciesList.RemoveCurrency(currency.currencyID);
    }

    private void DeleteAllCurrency()
    {
        CurrenciesList.HardResetList();
    }
}