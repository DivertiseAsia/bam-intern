using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wish : MonoBehaviour
{
    float rareRate = 0.2f;
    float epicRate = 0.15f;
    float legendaryRate = 0.05f;

    [SerializeField] Banner banner;
    [SerializeField] int SetCount = 10;

    //[SerializeField] Image displayImage;
    [SerializeField] int spendingCurrencyPerWish = 3;

    //Image display => GetComponent<Image>();

    private void Start()
    {
    }

    private void CheckItemRarity()
    {
        if (!banner.itemListInBanner.Find(_i => (int)_i.GetRarity() == (int)Rarity.rare))
            rareRate = 0;
        if (!banner.itemListInBanner.Find(_i => (int)_i.GetRarity() == (int)Rarity.epic))
            epicRate = 0;
        if (!banner.itemListInBanner.Find(_i => (int)_i.GetRarity() == (int)Rarity.legendary))
            epicRate = 0;
    }

    public int GetSpendingPerWish()
    {
        return spendingCurrencyPerWish;
    }
    public int GetSetCount()
    {
        return SetCount;
    }

    public void Roll()
    {
        CheckItemRarity();
        float number = Random.value;
        WishReport.self.resultItem.Add(checkRate(number));
    }


    public void RollSet()
    {
        for (int i = 0; i < SetCount; i++)
        {
            Roll();
        }
    }

    Item checkRate(float number)
    {
        if (banner.guaranteeFlag) {
            return GetLegendary();;
        }

        if (number > rareRate) return GetCommon();
        else if (number > epicRate) return GetRare();
        else if (number > legendaryRate) return GetEpic();
        else return GetLegendary();
    }

    Item GetLegendary()
    {
        //display.color = legendary;
        banner.AddLegendary();
        Debug.Log("Get Legendary");
        return DrawFromList(banner.legendaryList);
    }

    Item GetEpic()
    {
        banner.AddCount();
        //display.color = Epic;
        return DrawFromList(banner.epicList);
        //banner.AddEpic();
    }
    Item GetRare()
    {
        banner.AddCount();
        //display.color = rare;
        return DrawFromList(banner.rareList);
        //banner.AddRare();
    }
    Item GetCommon()
    {
        banner.AddCount();
        //display.color = common;
        return DrawFromList(banner.commonList);
    }

    Item DrawFromList(List<Item> itemList)
    {
        //check if Banner is normal or limited
        if (CheckLimitedBanner())
        {
            Item item = null;
            if (Random.value < banner.GetComponent<Limitedbanner>().rateUpRate) item = DrawRateUp(itemList[0].GetRarity());
            if (item != null)
            {
                //DisplayItem(item);
                return item;
            }
        }
        int _n = Random.Range(0, itemList.Count);
        //DisplayItem(itemList[_n]);
        return itemList[_n];
    }

    Item DrawRateUp(int rarity)
    {
        List<Item> RateUpItem = banner.GetComponent<Limitedbanner>().rateUpItem.FindAll(i => i.GetRarity() == rarity);
        if (RateUpItem.Count != 0)
        {
            int _n = Random.Range(0, RateUpItem.Count);
            return RateUpItem[_n];
        }
        return null;
    }

    bool CheckLimitedBanner()
    {
        if (banner.GetComponent<Limitedbanner>()) return true;
        return false;
    }

    #region Legacy
    /*
    void DisplayItem(Item item)
    {
        displayImage.sprite = item.GetItemIcon();
        displayImage.SetNativeSize();
        displayImage.rectTransform.localScale = Vector3.one * 0.25f;
    }
    */
    #endregion
}
