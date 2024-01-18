using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithList : MonoBehaviour
{
    RectTransform rectTransform => GetComponent<RectTransform>();
    ItemThumbnail[] icons;
    bool unchange;
    float yMax = 0;
    float yMin = 0;
    float yDefault = 0;

    private void Start()
    {
        unchange = true;
        yDefault = rectTransform.sizeDelta.y;
    }
    void Update()
    {
        if (unchange) CheckSize();
    }

    void CheckSize()
    {
        icons = GetComponentsInChildren<ItemThumbnail>();
        foreach (ItemThumbnail icon in icons)
        {
            RegistY(icon.gameObject.GetComponent<RectTransform>());
        }

        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, yMax - yMin);
        if (rectTransform.sizeDelta.y > yDefault) 
        { 
            unchange = false; 
        }
    }

    void RegistY(RectTransform icon)
    {
        if (yMax < icon.position.y + icon.rect.y * 0.5f)
        {
            yMax = icon.position.y + icon.rect.y * 0.5f;
        }

        if (yMin > icon.position.y - icon.rect.y * 0.5f)
        {
            
            yMin = icon.position.y - icon.rect.y * 0.5f;
        }
    }
}
