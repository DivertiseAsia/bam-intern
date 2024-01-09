using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTemplate", menuName = "Item/WeaponTemplate")]
public class WeaponTemplateScriptableObject : ItemTemplateScriptableObject
{
    public WeaponTemplateScriptableObject()
    {
        itemType = ItemType.weapon;
    }
}
