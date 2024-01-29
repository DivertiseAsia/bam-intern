using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum WeaponClass
{
    sword,
    bow,
    axe
}

public class Weapon : Item
{
    public WeaponTemplateScriptableObject _itemTemplate;
    public WeaponClass weaponClass = WeaponClass.sword;
    public void attackSkill()
    {
        Debug.Log("I attacked with: ");
    }

    public override void SetTemplate()
    {
        base.itemTemplate = itemTemplate;
        base.name = _itemTemplate.name;
        base.description = _itemTemplate.description;
        base.rarity = _itemTemplate.rarity;
        base.itemType = _itemTemplate.itemType;
        //base.sprite.sprite = itemTemplate.itemIcon;
        weaponClass = _itemTemplate.weaponClass;
    }
}
