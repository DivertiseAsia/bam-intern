using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System;

[Serializable]
public class Currency : System.Object
{
    [SerializeField] public CurrencyScriptableObject currencyTemplate;
    public int currencyID;
    private string name;
    private Sprite currencyIcon;
    private int maxCapa;

    public Currency(string _name, int _id, int _maxCapa, Sprite _icon)
    {
        name = _name;
        currencyID = _id;
        maxCapa = _maxCapa;
        currencyIcon = _icon;
    }

    public Currency(string _name, int _id)
    {
        name = _name;
        currencyID = _id;
    }

    public Currency(CurrencyScriptableObject _currency)
    {
        name = _currency.currencyName;
        currencyID = _currency.list.getCount();
        currencyIcon = _currency.currencyIcon;
        maxCapa = _currency.maxCapa;
    }

    public Currency()
    {
        name = "Dummy";
        maxCapa = 9999;
    }

    [ContextMenu("Project Exclusive/New Test Currency")]
    public void CreateNewCurrency()
    {
        Debug.Log("Hey");
    }

    public string GetName()
    {
        return name;
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
        name = c.currencyName;
        currencyIcon = c.currencyIcon;
        maxCapa = c.maxCapa;
    }
}

[CreateAssetMenu(fileName = "NewCurrency", menuName = "Project Exclusive/Currency/New Currency")]
public class CurrencyScriptableObject : ScriptableObject
{
    public string currencyName = "Dummy";
    public Sprite currencyIcon;
    public int maxCapa = 9999;
    public CurrenciesList list;
    public string path;

    public CurrencyScriptableObject()
    {
        path = "D:/Games/DivertiseAsiaIntern/bam-intern/Assets/Currency";
    }
}

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
        EditorGUILayout.PrefixLabel("Add To");
        currency.list = (CurrenciesList)EditorGUILayout.ObjectField(currency.list, typeof(CurrenciesList), false);
        EditorGUILayout.PrefixLabel("Currency Detail");

        if (currency.list == null) return;

        if (currency.list.getCount() != 0 && currency.list.FindCurrency(currency.name) != null) 
            EditorGUILayout.LabelField("ID", currency.list.FindCurrency(currency.name).currencyID + " (Added)");
        else EditorGUILayout.LabelField("ID", (currency.list.getCount()) + "");
        currency.currencyName = EditorGUILayout.TextField("Name", currency.currencyName);
        currency.maxCapa = EditorGUILayout.IntField("Max Capacity", currency.maxCapa);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Currrency Icon");
        currency.currencyIcon = (Sprite)EditorGUILayout.ObjectField(currency.currencyIcon, typeof(Sprite), false, GUILayout.Width(65f), GUILayout.Height(65f));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        currency.path = EditorGUILayout.TextField("Path", currency.path);
        if (GUILayout.Button("Save Path", GUILayout.Width(10f), GUILayout.Height(10f)))
        {
            currency.path = EditorUtility.OpenFolderPanel("Save at", "", "");
        }
        EditorGUILayout.EndHorizontal();

        if (currency.list.FindCurrency(currency.name) != null)
        {
            if (GUILayout.Button("Edit Currency"))
                EditCurrency(currency.list.FindCurrency(currency.name).currencyID);
        }
        else {
            if (GUILayout.Button("Add Currency To List"))
                AddCurrency();
        }
        EditorUtility.SetDirty(currency);
    }
    private void AddCurrency()
    {
        Currency _c = new Currency(currency);
        currency.list.AddCurrency(_c);
        Debug.Log("Object created: " + _c + ". Type: " + _c.GetType());
    }

    private void EditCurrency(int _id)
    {
        currency.list.FindCurrency(_id).Edit(currency);
        Currency _c = currency.list.FindCurrency(_id);
        Debug.Log("Object edit at: " + _id + ". Now: " + _c);
    }
}