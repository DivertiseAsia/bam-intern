using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitedbanner : Banner
{

    [SerializeField] UDateTime startDate = System.DateTime.Now;
    [SerializeField] UDateTime endDate = System.DateTime.Now;
    [SerializeField] List<Item> notPermanentItemList;
    [SerializeField] public List<Item> rateUpItem;
    public float rateUpRate = 0.7f;

    private new void Start()
    {
        itemListInBanner = ItemListing.permanentItemList;
        AddMoreItemToList(itemListInBanner, notPermanentItemList);
        RemoveRateUpItem(itemListInBanner, rateUpItem);
        CreateListByRarity(itemListInBanner);
    }
    private new void Update()
    {
        /*
        textInfo.text = "Count: " + count + "\n" +
            "R: " + rareCount + "\n" +
            "SR: " + epicCount + "\n" +
            "SSR: " + legendaryCount;
        */
        CheckGuarantee();
        CheckBannerEnd();
    }

    private void AddMoreItemToList(List<Item> itemList,List<Item> addingItemList)
    {
        foreach (Item item in addingItemList)
        {
            itemList.Add(item);
        }
    }

    private void RemoveRateUpItem(List<Item> itemList, List<Item> rateUpItemList)
    {
        foreach (Item item in rateUpItemList)
        {
            itemList.Remove(itemList.Find(i => i.GetInstanceID() == item.GetInstanceID()));
        }
    }

    private void CheckBannerEnd()
    {
        if (System.DateTime.Now > endDate)
        {
            EndBanner();
        }
    }

    private void EndBanner()
    {
        Destroy(gameObject);
    }
}
