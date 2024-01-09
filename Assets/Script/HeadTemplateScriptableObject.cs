using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeadTemplate", menuName = "Item/HeadTemplate")]
public class HeadTemplateScriptableObject : ItemTemplateScriptableObject
{
    public float defPoint;
    public HeadTemplateScriptableObject()
    {
        itemType = ItemType.head;
    }
}
