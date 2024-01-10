using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
