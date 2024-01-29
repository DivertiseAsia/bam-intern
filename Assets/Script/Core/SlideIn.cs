using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
    [SerializeField] bool activate;
    RectTransform rect => GetComponent<RectTransform>();

    public void Update()
    {
        CheckTouchArea();
    }

    public void Toggle()
    {
        if (activate) activate = false; else activate = true;
    }

    // Update is called once per frame
    public void CheckTouchArea()
    {
        if (activate)
        {
            SlideNaviDown();
        }

        else
        {
            SlideNaviUp();
        }
    }
    void SlideNaviDown()
    {
        rect.SetLocalPositionAndRotation(new Vector2(0, 120), Quaternion.identity);
    }

    void SlideNaviUp()
    {
        rect.SetLocalPositionAndRotation(new Vector2(0, 300), Quaternion.identity);
    }
}
