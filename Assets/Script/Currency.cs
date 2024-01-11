using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class Currency : Object
{
    [SerializeField] public CurrencyScriptableObject currencyTemplate;
    public int currencyID;
    private new string name;
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
        currencyID = _currency.list.getCount() - 1;
        currencyIcon = _currency.currencyIcon;
        maxCapa = _currency.maxCapa;
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
    public string currencyName;
    public Sprite currencyIcon;
    public int maxCapa;
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

        if (currency.list.getCount() != 0 && currency.list.FindCurrency(currency.name)) EditorGUILayout.LabelField("ID", "Added To List");
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

        if (GUILayout.Button("Add Currency To List")) AddCurrency();

        EditorUtility.SetDirty(currency);


    }
    private void AddCurrency()
    {
        //this line is null
        Currency _c = new Currency(currency.name, (currency.list.getCount()), currency.maxCapa, currency.currencyIcon);
        AssetDatabase.AddObjectToAsset(_c, currency.path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}