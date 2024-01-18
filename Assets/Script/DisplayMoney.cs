using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour
{
    Account player;
    TMP_Text text;
    int amount;
    [SerializeField] string currency;

    void Start()
    {
        player = FindObjectOfType<Account>();
        text = transform.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        amount = FindAmount();
        text.text = amount + "" + currency;
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
}
