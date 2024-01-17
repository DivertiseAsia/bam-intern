using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TakeFrom
{
    account,
    report
} 

public class DisplayList : MonoBehaviour
{
    [SerializeField] ItemThumbnail thumbnailTemplate;
    [SerializeField] List<Item> toList;
    [SerializeField] TakeFrom takefrom = TakeFrom.account;
    [SerializeField] GameObject warnLabel;
    int row;
    int column;

    public void Start()
    {
        TakeFromWho(takefrom);

        thumbnailTemplate.gameObject.SetActive(false);
        if (toList.Count == 0) warnLabel.SetActive(true);
        else
        {
            warnLabel.SetActive(false);
            listItem(toList);
        }

    }

    private void TakeFromWho(TakeFrom takefrom)
    {
        if ((int)takefrom == (int)TakeFrom.account)
        {
            toList = FindObjectOfType<OwnedItemList>().ownedItem;
        }
        else if ((int)takefrom == (int)TakeFrom.report)
        {
            toList = FindObjectOfType<WishReport>().resultItem;
        }
    }

    private void listItem(List<Item> toList)
    {
        row = 0;
        column = (int)(transform.GetComponent<RectTransform>().rect.x / thumbnailTemplate.transform.GetComponent<RectTransform>().rect.x);
        if (column == 0)
        {
            column = (int)(transform.parent.parent.GetComponent<RectTransform>().rect.x / thumbnailTemplate.transform.GetComponent<RectTransform>().rect.x);
        }

        for (int i = 0; i < toList.Count; i++)
        {
            GameObject itemThumbnail = Instantiate(thumbnailTemplate.gameObject, transform);
            itemThumbnail.GetComponent<ItemThumbnail>().itemTemplate = toList[i].GetTemplate();
            itemThumbnail.transform.position += Vector3.left * (i % column * itemThumbnail.GetComponent<RectTransform>().rect.x) * 2;
            itemThumbnail.transform.position += Vector3.up * ((int)(i / column * itemThumbnail.GetComponent<RectTransform>().rect.y) * 2);
            itemThumbnail.SetActive(true);
        }
    }
}
