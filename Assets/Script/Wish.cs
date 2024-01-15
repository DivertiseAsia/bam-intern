using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wish : MonoBehaviour
{
    [SerializeField] Color common = Color.gray;
    [SerializeField] Color rare = Color.green;
    float rareRate = 0.2f;
    [SerializeField] Color Epic = Color.cyan;
    float EpicRate = 0.15f;
    [SerializeField] Color legendary = Color.yellow;
    float legendaryRate = 0.05f;

    [SerializeField] Banner banner;
    [SerializeField] int SetCount = 10;

    [SerializeField] Image displayImage;
    [SerializeField] int spendingCurrencyPerWish;

    Image display => GetComponent<Image>();

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
        float number = Random.value;
        checkRate(number);
    }


    public void RollSet()
    {
        StartCoroutine(PauseforaFrame());
    }

    IEnumerator PauseforaFrame ()
    {
        for (int i = 0; i < SetCount; i++)
        {
            Roll();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void checkRate(float number)
    {
        if (banner.guaranteeFlag) {
            GetLegendary();
            return;
        }

        if (number > rareRate) GetCommon();
        else if (number > EpicRate) GetRare();
        else if (number > legendaryRate) GetEpic();
        else GetLegendary();

        banner.AddCount();
    }

    void GetLegendary()
    {
        display.color = legendary;
        DrawFromList(banner.legendaryList);
        banner.AddLegendary();
    }
    void GetEpic()
    {
        display.color = Epic;
        DrawFromList(banner.epicList);
        banner.AddEpic();
    }
    void GetRare()
    {
        display.color = rare;
        DrawFromList(banner.rareList);
        banner.AddRare();
    }
    void GetCommon()
    {
        display.color = common;
        DrawFromList(banner.commonList);
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
                DisplayItem(item);
                return item;
            }
        }
        int _n = Random.Range(0, itemList.Count);
        DisplayItem(itemList[_n]);
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

    void DisplayItem(Item item)
    {
        displayImage.sprite = item.GetItemIcon();
        displayImage.SetNativeSize();
        displayImage.rectTransform.localScale = Vector3.one * 0.25f;
    }

    bool CheckLimitedBanner()
    {
        if (banner.GetComponent<Limitedbanner>()) return true;
        return false;
    }
}
