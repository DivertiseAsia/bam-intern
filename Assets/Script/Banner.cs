using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banner : MonoBehaviour
{
    public int bannerId;
    //protected TextMeshProUGUI textInfo => GetComponent<TextMeshProUGUI>();
    [SerializeField] int guaranteeCount = 50;

    protected int count = 0;

    public bool guaranteeFlag = false;

    [HideInInspector] public List<Item> itemListInBanner;

    [HideInInspector] public List<Item> commonList = new List<Item>();
    [HideInInspector] public List<Item> rareList = new List<Item>();
    [HideInInspector] public List<Item> epicList = new List<Item>();
    [HideInInspector] public List<Item> legendaryList = new List<Item>();

    [SerializeField] protected TMP_Text GuaranteeText;

    Account account => FindObjectOfType<Account>();

    protected void Start()
    {
        count = account.GetGuarantee(bannerId);
        itemListInBanner = ItemListing.permanentItemList;
        CreateListByRarity(itemListInBanner);
    }
    protected void Update()
    {
        /*
        textInfo.text = "Count: " + count + "\n" +
            "R: " + rareCount + "\n" +
            "SR: " + epicCount + "\n" +
            "SSR: " + legendaryCount;
        */
        CheckGuarantee();
    }

    public void CreateListByRarity(List<Item> itemList)
    {
        foreach (Item item in itemList)
        {
            if (item.GetRarity() == (int)Rarity.common) commonList.Add(item);
            else if (item.GetRarity() == (int)Rarity.rare) rareList.Add(item);
            else if (item.GetRarity() == (int)Rarity.epic) epicList.Add(item);
            else if (item.GetRarity() == (int)Rarity.legendary) legendaryList.Add(item);
        }
    }
    private static bool keyUnholded = true;
    public void AddCount() {
        if (keyUnholded)
        {
            keyUnholded = false;
            count += 1;
            account.SaveGuarantee(bannerId, count);
            keyUnholded = true;
        }
    }
    public void ResetCount() { count = 0; }

    protected void CheckGuarantee()
    {
        GuaranteeText.text = "Roll " + (guaranteeCount - count) + " more item(s) to guarantee SSR item.";
        if (count < guaranteeCount)
        {
            guaranteeFlag = false;
            return;
        }
        guaranteeFlag = true;
    }
}

[Serializable]
public class CountOnBanner
{
    public int bannerId;
    public int count;

    public CountOnBanner(int _bannerId, int _count)
    {
        bannerId = _bannerId;
        count = _count;
    }
}

[Serializable]
public class CountList{
    public List<CountOnBanner> countList;
}