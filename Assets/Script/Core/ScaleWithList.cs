using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithList : MonoBehaviour
{
    RectTransform rectTransform => GetComponent<RectTransform>();
    [SerializeField] RectTransform icon;
    OwnedItemList ownedItem => FindObjectOfType<OwnedItemList>();
    float iconHeight;

    void Update()
    {
        CheckSize();
    }

    void CheckSize()
    {
        iconHeight = icon.sizeDelta.y;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, iconHeight * ownedItem.ownedItem.Count * 0.5f);

    }
}
