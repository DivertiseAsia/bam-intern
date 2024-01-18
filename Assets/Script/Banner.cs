using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banner : MonoBehaviour
{
    //protected TextMeshProUGUI textInfo => GetComponent<TextMeshProUGUI>();
    [SerializeField] int guaranteeCount = 50;

    protected static int count = 0;
    protected static int rareCount = 0;
    protected static int epicCount = 0;
    protected static int legendaryCount = 0;

    public bool guaranteeFlag = false;

    [HideInInspector] public List<Item> itemListInBanner;

    [HideInInspector] public List<Item> commonList = new List<Item>();
    [HideInInspector] public List<Item> rareList = new List<Item>();
    [HideInInspector] public List<Item> epicList = new List<Item>();
    [HideInInspector] public List<Item> legendaryList = new List<Item>();

    [SerializeField] protected TMP_Text GuaranteeText;

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
        GuaranteeText.text = "Roll " + (guaranteeCount - count) + " more item(s) to guarantee SSR item.";
        if (count < guaranteeCount)
        {
            guaranteeFlag = false;
            return;
        }
        guaranteeFlag = true;
    }
}
