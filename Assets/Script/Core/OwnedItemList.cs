using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedItemList : MonoBehaviour
{
    public List<Item> ownedItem = new List<Item>();
    // Start is called before the first frame update
    public List<Item> AddItem(Item item)
    {
        ownedItem.Add(item);
        return ownedItem;
    }

    public List<Item> AddItem(List<Item> itemList)
    {
        foreach (Item item in itemList)
        {
            ownedItem.Add(item);
        }
        return ownedItem;
    }

    public List<Item> RemoveItem(int index)
    {
        ownedItem.RemoveAt(index);
        return ownedItem;
    }

    public List<Item> GetItem()
    {
        return ownedItem;
    }
}
