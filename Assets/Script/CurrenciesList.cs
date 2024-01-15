using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class CurrenciesList : MonoBehaviour
{
    public List<Currency> currencyList;
    public CurrenciesList()
    {
        currencyList = new List<Currency>();
    }
    public int getCount()
    {
        if (currencyList == null) return 0;
        return currencyList.Count;
    }
    public void AddCurrency(Currency currency)
    {
        currencyList.Add(currency);
    }

    public Currency FindCurrency(string currencyName)
    {
        Currency c = currencyList.Find(_c => _c.GetName().Equals(currencyName));
        return c;
    }

    public Currency FindCurrency(int id)
    {
        Currency c = currencyList.Find(_c => _c.currencyID == id);
        return c;
    }

    public bool CheckInList(string currencyName)
    {
        return FindCurrency(currencyName) != null;
    }
    public bool CheckInList(int id)
    {
        return FindCurrency(id) != null;
    }

    public void RemoveCurrency(string currencyName)
    {
        //if (currencyList.IsNull)
        currencyList.Remove(currencyList.Find(_c => _c.GetName().Equals(currencyName)));
    }
    public void RemoveCurrency(int id)
    {
        currencyList.Remove(currencyList.Find(_c => _c.currencyID == id));
    }

    public void HardResetList()
    {
        currencyList = new List<Currency>();
    }
}

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

#region Legacy
/*
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

public class CurrencyListGameObject : MonoBehaviour
{
    [SerializeField] private List<Currency> _currencyList = new List<Currency>();
    public static List<Currency> currencyList;

    [ExecuteInEditMode]
    private void UpdateAlways()
    {
        currencyList = _currencyList;
        CurrenciesList.setCurrenciesList(currencyList);
    }

}

*/

#endregion