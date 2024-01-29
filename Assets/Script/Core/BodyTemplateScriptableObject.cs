using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTemplateScriptableObject : ItemTemplateScriptableObject
{
    public float atkPoint;
    public BodyTemplateScriptableObject()
    {
        itemType = ItemType.body;
    }
}
