using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemTemplateScriptableObject : ScriptableObject
{
    public Sprite itemIcon;
    public new string name = "ItemName";
    public string description;
    public Rarity rarity = Rarity.common;
    public ItemType itemType;
    public GameObject itemRef;
}
