using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banner : MonoBehaviour
{
    //protected TextMeshProUGUI textInfo => GetComponent<TextMeshProUGUI>();
    [SerializeField] int guaranteeCount = 50;

    protected int count = 0;
    protected int rareCount = 0;
    protected int epicCount = 0;
    protected int legendaryCount = 0;

    public bool guaranteeFlag = false;

    [HideInInspector] public List<Item> itemListInBanner;

    [HideInInspector] public List<Item> commonList = new List<Item>();
    [HideInInspector] public List<Item> rareList = new List<Item>();
    [HideInInspector] public List<Item> epicList = new List<Item>();
    [HideInInspector] public List<Item> legendaryList = new List<Item>();

    protected void Start()
    {
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

    public void AddCount() { count += 1; }
    public void AddRare() { rareCount += 1; }
    public void AddEpic() { epicCount += 1; }
    public void AddLegendary() { legendaryCount += 1; count = 0; }

    protected void CheckGuarantee()
    {
        if (count < guaranteeCount)
        {
            guaranteeFlag = false;
            return;
        }
        guaranteeFlag = true;
    }
}
