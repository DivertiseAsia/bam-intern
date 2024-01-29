using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMoney : MonoBehaviour
{
    [SerializeField] private Account targetAcc;
    [SerializeField] private CurrenciesList currencieslist;
    [SerializeField] string currencyName;
    [SerializeField] int amount;
    Wish wish => GetComponent<Wish>();
    [HideInInspector] public bool nextScene;

    [SerializeField] private int rollTime = 1;

    private void Start()
    {
        targetAcc = FindObjectOfType<Account>();
    }

    private void Update()
    {
        if (wish != null) wish.CheckMoney(targetAcc.GetMoney(currencyName), rollTime);
    }
    public void TopUp()
    {
        if (targetAcc.FindCurrencyInWallet(currencyName) != null)
        {
            targetAcc.TopUp(currencyName, amount);
        }
        else
        {
            if (!currencieslist.CheckInList(currencyName))
            {
                Debug.Log("Cannot Find This Currency");
                return;
            }
            Currency c = currencieslist.FindCurrency(currencyName);
            targetAcc.AddToWallet(c, amount);
        }

        Debug.Log("Money in the account: " + targetAcc.GetMoney(currencyName) + currencyName);
    }

    public void Spend()
    {
        if (targetAcc.FindCurrencyInWallet(currencyName) != null)
        {
            if (!currencieslist.CheckInList(currencyName))
            {
                Debug.Log("This Currency Is Not Existed");
                return;
            }

            if (targetAcc.GetMoney(currencyName) <= 0)
            {
                Debug.Log("Run out of money!");
                return;
            }

            targetAcc.Spend(currencyName, amount);
        }
        else
        {
            Debug.Log("Cannot find money with this Currency");
        }
    }

    public void Spend(int _amount)
    {
        if (targetAcc.FindCurrencyInWallet(currencyName) != null)
        {
            if (!currencieslist.CheckInList(currencyName))
            {
                Debug.Log("This Currency Is Not Existed");
                return;
            }

            if (targetAcc.GetMoney(currencyName) <= 0)
            {
                Debug.Log("Run out of money!");
                return;
            }

            targetAcc.Spend(currencyName, _amount);
        }
        else
        {
            Debug.Log("Cannot find money with this Currency");
        }
    }

    public void Roll()
    {
        if (targetAcc.GetMoney(currencyName) < wish.GetSpendingPerWish())
        {
            Debug.Log("Too low to spend " + wish.GetSpendingPerWish() + " here");
            return;
        }
        Spend();
        wish.Roll();
        nextScene = true;
    }
    public void RollSet()
    {
        if (targetAcc.GetMoney(currencyName) < wish.GetSpendingPerWish() * wish.GetSetCount())
        {
            Debug.Log("Too low to spend "+ wish.GetSpendingPerWish() * wish.GetSetCount() + " here");
            return;
        }
        Spend();
        wish.RollSet();
        nextScene = true;
    }

}
