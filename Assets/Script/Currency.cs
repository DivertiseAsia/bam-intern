using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Currency : Object
{
    public int currencyID;
    private string currencyName;
    private Sprite currencyIcon;
    private int maxCapa;

    public Currency(string _name, int _id, int _maxCapa)
    {
        currencyName = _name;
        currencyID = _id;
        maxCapa = _maxCapa;
    }

    public Currency(string _name, int _id)
    {
        currencyName = _name;
        currencyID = _id;
    }

    public Currency(CurrencyScriptableObject _currency)
    {
        currencyName = _currency.currencyName;
        currencyID = _currency.currencyID;
        currencyIcon = _currency.currencyIcon;
        maxCapa = _currency.maxCapa;
    }

    public string GetName()
    {
        return currencyName;
    }

    public Sprite GetIcon()
    {
        return currencyIcon;
    }

    public int GetMaxCapa()
    {
        return maxCapa;
    }

    public void Edit(CurrencyScriptableObject c)
    {
        currencyName = c.currencyName;
        currencyIcon = c.currencyIcon;
        maxCapa = c.maxCapa;
    }
}

public static class CurrenciesList
{
    public static List<Currency> staticCurrenciesCollector;

    static CurrenciesList()
    {
        staticCurrenciesCollector = new List<Currency>();
    }

    public static void setCurrenciesList(List<Currency> newList)
    {
        staticCurrenciesCollector = newList;
    }

    public static int getCount()
    {
        if (staticCurrenciesCollector == null) return 0;
        return staticCurrenciesCollector.Count;
    }
    public static void AddCurrency(Currency currency)
    {
        staticCurrenciesCollector.Add(currency);
    }

    public static Currency FindCurrency(string currencyName)
    {
        return staticCurrenciesCollector.Find(_c => _c.GetName().Equals(currencyName));
    }

    public static Currency FindCurrency(int id)
    {
        return staticCurrenciesCollector.Find(_c => _c.currencyID == id);
    }

    public static void RemoveCurrency(string currencyName)
    {
        staticCurrenciesCollector.Remove(staticCurrenciesCollector.Find(_c => _c.GetName().Equals(currencyName)));
    }
    public static void RemoveCurrency(int id)
    {
        staticCurrenciesCollector.Remove(staticCurrenciesCollector.Find(_c => _c.currencyID == id));
    }

    public static void HardResetList()
    {
        staticCurrenciesCollector = new List<Currency>();
    }
}


public class CurrenciesListEditor: EditorWindow
{
    [MenuItem("Window/Game Exclusive/Currencies List")]
    public static void ShowWindow()
    {
        CurrenciesListEditor wnd = GetWindow<CurrenciesListEditor>();
        wnd.titleContent = new GUIContent("Currencies List");
    }

    public void CreateGUI()
    {
        Label lable = new Label("Count: " + CurrenciesList.getCount());
        rootVisualElement.Add(lable);
    }
}