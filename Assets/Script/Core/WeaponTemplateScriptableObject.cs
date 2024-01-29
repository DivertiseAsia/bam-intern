using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTemplateScriptableObject : ItemTemplateScriptableObject
{
    public WeaponClass weaponClass;
    public WeaponTemplateScriptableObject()
    {
        itemType = ItemType.weapon;
    }
}
