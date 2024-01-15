using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyTemplate", menuName = "Project Exclusive/Item/Body Template")]
public class BodyTemplateScriptableObject : ItemTemplateScriptableObject
{
    public float atkPoint;
    public BodyTemplateScriptableObject()
    {
        itemType = ItemType.body;
    }
}
