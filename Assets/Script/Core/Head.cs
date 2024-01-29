using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Head : Item
{
    public HeadTemplateScriptableObject _itemTemplate;
    float defATK;
    static int count = 0;

    public override void SetTemplate()
    {
        base.itemTemplate = itemTemplate;
        base.name = _itemTemplate.name;
        base.description = _itemTemplate.description;
        base.rarity = _itemTemplate.rarity;
        base.itemType = _itemTemplate.itemType;
        //base.sprite.sprite = itemTemplate.itemIcon;
        defATK = _itemTemplate.defPoint;
    }
}
