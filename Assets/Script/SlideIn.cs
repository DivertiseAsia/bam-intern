using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
    [SerializeField] bool activate;

    // Update is called once per frame
    public void CheckTouchArea()
    {
        if (!activate)
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
        activate = true;
        transform.position = new Vector3(382, 310, 0);
    }

    void SlideNaviUp()
    {
        activate = false;
        transform.position = new Vector3(382, 466, 0);
    }
}
