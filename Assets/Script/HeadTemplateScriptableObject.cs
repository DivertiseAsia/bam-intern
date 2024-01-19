using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTemplateScriptableObject : ItemTemplateScriptableObject
{
    public float defPoint;
    public HeadTemplateScriptableObject()
    {
        itemType = ItemType.head;
    }
}
