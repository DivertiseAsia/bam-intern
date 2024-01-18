using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account : MonoBehaviour
{
    private static Account self;
    [SerializeField] protected int accountId;
    [SerializeField] protected string accName;
    [SerializeField] protected string message;
    [SerializeField] protected List<Money> wallet = new List<Money>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null) self = this;
        else Destroy(gameObject);
    }
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
            Debug.Log("This Money currency is not found");
        }
        m.TopUp(amount);
    }

    public void Spend(string currencyName, int amount)
    {
        if (wallet.Count == 0) Debug.Log("Wallet is Empty");
        Money m = wallet.Find(_m => _m.GetCurrencyName() == currencyName);
        m.Spend(amount);
    }

    public int GetMoney(string currencyName)
    {
        if (wallet.Count == 0) return 0;
        if (FindCurrencyInWallet(currencyName) == null) return 0;
        return wallet.Find(_m => _m.GetCurrencyName().Equals(currencyName)).GetAmount();
    }

    public Money FindCurrencyInWallet(string currencyName)
    {
        if (wallet.Count == 0)
        {
            return null;
        }
        return wallet.Find(_m => _m.GetCurrencyName().Equals(currencyName));
    }
    public Money FindCurrencyInWallet(int currencyId)
    {
        if (wallet.Count == 0)
        {
            Debug.Log("Wallet is Empty");
            return null;
        }
        return wallet.Find(_m => _m.GetCurrencyID() == currencyId);
    }
}


public class Money : System.Object
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

    public int GetAmount()
    {
        return amount;
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
