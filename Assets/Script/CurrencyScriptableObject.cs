using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

[CreateAssetMenu(fileName = "NewCurrency", menuName = "Project Exclusive/Currency")]
public class CurrencyScriptableObject : ScriptableObject
{
    public int currencyID;
    public string currencyName;
    public Sprite currencyIcon;
    public int maxCapa;

}
