using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    A,
    B
}

public class Currency : MonoBehaviour
{
    private CurrencyType currencyType = CurrencyType.A;
    private Sprite currencyIcon;
    private int maximumCapacityPerPerson;

    public Currency(CurrencyType _currencyType, int _maximumcapacity, int _amount)
    {
        currencyType = _currencyType;
        maximumCapacityPerPerson = _maximumcapacity;
    }

    public CurrencyType GetType()
    {
        return currencyType;
    }

    public Sprite GetIcon()
    {
        return currencyIcon;
    }

    public int GetMaxCapa()
    {
        return maximumCapacityPerPerson;
    }
}
