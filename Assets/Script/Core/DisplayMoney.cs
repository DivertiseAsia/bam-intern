using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayMoney : MonoBehaviour
{
    Account player;
    TMP_Text text;
    Image currencyIcon;
    int amount;
    [SerializeField] string currency;

    void Start()
    {
        player = FindObjectOfType<Account>();
        text = transform.GetComponentInChildren<TMP_Text>();
        currencyIcon = transform.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        amount = FindAmount();
        text.text = amount + "" + currency;
        currencyIcon.sprite = FindIcon();
    }

    int FindAmount()
    {
        Money _m = player.FindCurrencyInWallet(currency);
        if (_m == null)
        {
            return 0;
        }
        return _m.GetAmount();
    }

    Sprite FindIcon()
    {
        Money _m = player.FindCurrencyInWallet(currency);
        if (_m == null)
        {
            return null;
        }
        return _m.currency.currencyIcon;
    }
}
