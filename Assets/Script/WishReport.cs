using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishReport : MonoBehaviour
{
    public List<Item> resultItem;
    private GameObject player;
    [HideInInspector] public static WishReport self;

    // Update is called once per frame
    void Start()
    {
        player = FindAnyObjectByType<Account>().gameObject;
        DontDestroyOnLoad(this); //stay until the end of "Gacha Result Scene"

        if (self == null) self = this;
        else Destroy(gameObject);
    }

    public void EarnItemToPlayer()
    {
        player.GetComponent<OwnedItemList>().AddItem(resultItem);
        resultItem.Clear();
    }
}
