using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListing : MonoBehaviour
{
    public static List<Item> permanentItemList;
    [SerializeField] List<Item> _permanentItemList;
    void Awake()
    {
        permanentItemList = _permanentItemList;
    }
}
