using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTemplate", menuName = "Project Exclusive/Item/Weapon Template")]
public class WeaponTemplateScriptableObject : ItemTemplateScriptableObject
{
    public WeaponTemplateScriptableObject()
    {
        itemType = ItemType.weapon;
    }
}
