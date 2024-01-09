using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account : MonoBehaviour
{
    protected int accountId;
    protected string name;
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
    public void TopUp(Currency currency, int amount)
    {
        Money m = wallet.Find(_m => (int)_m.GetCurrencyType() == (int)currency.GetType());
        m.AddMoney(amount);
    }

    public void Spend(Currency currency, int amount)
    {
        Money m = wallet.Find(_m => (int)_m.GetCurrencyType() == (int)currency.GetType());
        m.UseMoney(amount);
    }


}

public class Money
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

    public CurrencyType GetCurrencyType()
    {
        return currency.GetType();
    }

    public void AddMoney(int addUp)
    {
        amount += addUp;
    }

    public void UseMoney(int used)
    {
        amount -= used;
    }
}