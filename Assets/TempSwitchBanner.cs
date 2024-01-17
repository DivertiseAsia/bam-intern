using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSwitchBanner : MonoBehaviour
{
    [SerializeField] GameObject currentBanner;
    [SerializeField] GameObject nextBanner;

    Vector3 oldBannerPosition;

    public void SwitchBanner()
    {
        oldBannerPosition = currentBanner.transform.position;
        currentBanner.transform.position = nextBanner.transform.position;
        nextBanner.transform.position = oldBannerPosition;
    }
}
