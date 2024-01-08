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

    Image display => GetComponent<Image>();

    // Start is called before the first frame update
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
            getSSR();
            return;
        }

        Debug.Log(number);
        if (number > rareRate) getGen();
        else if (number > EpicRate) getR();
        else if (number > legendaryRate) getSR();
        else getSSR();

        banner.AddCount();
    }

    void getSSR()
    {
        display.color = legendary;
        banner.AddLegendary();
    }
    void getSR()
    {
        display.color = Epic;
        banner.AddEpic();
    }
    void getR()
    {
        display.color = rare;
        banner.AddRare();
    }
    void getGen()
    {
        display.color = common;
    }
}
