using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollview : MonoBehaviour
{
    [SerializeField] RectTransform content;
    [SerializeField] Scrollbar handler;
    float ybottom = 0;
    float ytop = 0;
    void Update()
    {
        foreach (RectTransform children in content.transform.GetComponentInChildren<RectTransform>())
        {
            if (ytop < children.rect.yMax) ytop = children.rect.yMax;
            if (ybottom > children.rect.yMin) ytop = children.rect.yMin;
        }
        if (handler.value != 0) content.position = new Vector3(content.position.x, ytop - ybottom / handler.value, content.position.z);
        else content.position = new Vector3(content.position.x, ytop, content.position.z);
    }
}
