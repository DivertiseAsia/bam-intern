using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Account : MonoBehaviour
{
    private static Account self;
    [SerializeField] protected int accountId;
    [SerializeField] protected string accName;
    [SerializeField] protected string message;
    [SerializeField] protected Wallet wallet = new Wallet();
    [SerializeField] SavePlayerData savePlayerData;

    OwnedItemList owned => GetComponent<OwnedItemList>();
    PlayerEquip playerEquip => GetComponent<PlayerEquip>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (self == null) self = this;
        else Destroy(gameObject);

        if (savePlayerData != null) LoadSave();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        if (savePlayerData == null)
        {
            savePlayerData = ScriptableObject.CreateInstance<SavePlayerData>();
        }

        savePlayerData.accountId = accountId;
        savePlayerData.accName = accName;
        savePlayerData.message = message;
        savePlayerData.wallet = JsonUtility.ToJson(wallet);

        savePlayerData.owned = owned.ownedItem;
        savePlayerData.playerHeadEquip = playerEquip.headEquip;
        savePlayerData.playerBodyEquip = playerEquip.bodyEquip;
        savePlayerData.playerWeaponEquip = playerEquip.weaponEquip;
    }

    public void LoadSave()
    {
        accountId = savePlayerData.accountId;
        accName = savePlayerData.accName;
        message = savePlayerData.message;
        wallet = JsonUtility.FromJson<Wallet>(savePlayerData.wallet);
        if (savePlayerData.owned != null) owned.ownedItem = savePlayerData.owned;

        playerEquip.SetHead(savePlayerData.playerHeadEquip);
        playerEquip.SetBody(savePlayerData.playerBodyEquip);
        playerEquip.SetWeapon(savePlayerData.playerWeaponEquip);
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
        wallet.money.Add(new Money(currency, amount));
    }
    public void TopUp(string currencyName, int amount)
    {
        Money m = wallet.money.Find(_m => _m.GetCurrencyName() == currencyName);
        if (m == null)
        {
            Debug.Log("This Money currency is not found");
        }
        m.TopUp(amount);
    }

    public void Spend(string currencyName, int amount)
    {
        if (wallet.money.Count == 0) Debug.Log("Wallet is Empty");
        Money m = wallet.money.Find(_m => _m.GetCurrencyName() == currencyName);
        m.Spend(amount);
    }

    public int GetMoney(string currencyName)
    {
        if (wallet.money.Count == 0) return 0;
        if (FindCurrencyInWallet(currencyName) == null) return 0;

        return wallet.money.Find(_m => _m.GetCurrencyName().Equals(currencyName)).GetAmount();
        
    }

    public Money FindCurrencyInWallet(string currencyName)
    {
        if (wallet.money.Count == 0)
        {
            return null;
        }
        return wallet.money.Find(_m => _m.GetCurrencyName().Equals(currencyName));
    }
    public Money FindCurrencyInWallet(int currencyId)
    {
        if (wallet.money.Count == 0)
        {
            return null;
        }
        return wallet.money.Find(_m => _m.GetCurrencyID() == currencyId);
    }
}

[Serializable]
public class Money : System.Object
{
    public Currency currency;
    public int amount;

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

[Serializable]
public class Wallet
{
    public List<Money> money = new List<Money>();
}
