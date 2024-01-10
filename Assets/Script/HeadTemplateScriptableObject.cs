using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeadTemplate", menuName = "Project Exclusive/Item/Head Template")]
public class HeadTemplateScriptableObject : ItemTemplateScriptableObject
{
    public float defPoint;
    public HeadTemplateScriptableObject()
    {
        itemType = ItemType.head;
    }
}
