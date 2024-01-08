using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banner : MonoBehaviour
{
    TextMeshProUGUI textInfo => GetComponent<TextMeshProUGUI>();
    int guaranteeCount = 50;

    int count = 0;
    int rareCount = 0;
    int epicCount = 0;
    int legendaryCount = 0;

    public bool guaranteeFlag = false;

    private void Update()
    {
        textInfo.text = "Count: " + count + "\n" +
            "R: " + rareCount + "\n" +
            "SR: " + epicCount + "\n" +
            "SSR: " + legendaryCount;

        CheckGuarantee();
    }

    public void AddCount() { count += 1; }
    public void AddRare() { rareCount += 1; }
    public void AddEpic() { epicCount += 1; }
    public void AddLegendary() { legendaryCount += 1; count = 0; }

    private void CheckGuarantee()
    {
        if (count < guaranteeCount)
        {
            guaranteeFlag = false;
            return;
        }
        guaranteeFlag = true;
    }
}
