using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishReport : MonoBehaviour
{
    public List<Item> resultItem;
    private GameObject player;
    [HideInInspector] public static WishReport self; //singleton
    public RarityScript rarity; // for creating singleton

    // Update is called once per frame
    void Start()
    {
        player = FindAnyObjectByType<Account>().gameObject;
        DontDestroyOnLoad(this); //stay until the end of "Gacha Result Scene"

        if (self == null) self = this;
        else Destroy(gameObject);
    }

    public void EarnItemToPlayer(Item item)
    {
        player.GetComponent<OwnedItemList>().AddItem(item);
    }

    public void DestroyWishReport()
    {
        resultItem.Clear();
    }

    public void AddItem(Item item)
    {
        resultItem.Add(item);
        EarnItemToPlayer(item);
    }
}
