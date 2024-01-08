using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wish : MonoBehaviour
{
    [SerializeField] Color general = Color.gray;
    [SerializeField] Color rare = Color.green;
    float rareRate = 0.2f;
    [SerializeField] Color superRare = Color.cyan;
    float superRareRate = 0.15f;
    [SerializeField] Color specialSuperRare = Color.yellow;
    float specialSuperRareRate = 0.05f;

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
        else if (number > superRareRate) getR();
        else if (number > specialSuperRareRate) getSR();
        else getSSR();

        banner.AddCount();
    }

    void getSSR()
    {
        display.color = specialSuperRare;
        banner.AddSpecialSuperRare();
    }
    void getSR()
    {
        display.color = superRare;
        banner.AddSuperRare();
    }
    void getR()
    {
        display.color = rare;
        banner.AddRare();
    }
    void getGen()
    {
        display.color = general;
    }
}
