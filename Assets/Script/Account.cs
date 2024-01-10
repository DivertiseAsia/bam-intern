using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account : MonoBehaviour
{
    protected int accountId;
    protected string accName;
    protected string message;
    protected List<Item> ownedList;
    protected List<Money> wallet;

    public int GetAccountID()
    {
        return accountId;
    }

    public string GetName()
    {
        return name;
    }

    public void AddToWallet(Currency currency, int amount)
    {
        wallet.Add(new Money(currency, amount));
    }
    public void TopUp(string currencyName, int amount)
    {
        Money m = wallet.Find(_m => _m.GetCurrencyName() == currencyName);
        if (m == null)
        {

        }
        m.TopUp(amount);
    }

    public void Spend(string currencyName, int amount)
    {
        Money m = wallet.Find(_m => _m.GetCurrencyName() == currencyName);
        m.Spend(amount);
    }
}


public class Money : Object
{
    protected Currency currency;
    protected int amount;

    public Money(Currency _currency, int _amount)
    {
        currency = _currency;
        amount = _amount;
    }

    public Money(Currency _currency)
    {
        currency = _currency;
        amount = 0;
    }
    public int GetCurrencyID()
    {
        return currency.currencyID;
    }
    public string GetCurrencyName()
    {
        return currency.GetName();
    }

    public void TopUp(int addUp)
    {
        amount += addUp;
    }

    public void Spend(int used)
    {
        amount -= used;
    }
}
