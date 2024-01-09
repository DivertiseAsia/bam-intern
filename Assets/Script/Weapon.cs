using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponClass
{
    sword,
    bow,
    axe
}

public class Weapon : Item
{
    public WeaponClass weaponClass = WeaponClass.sword;
    public void attackSkill()
    {
        Debug.Log("I attacked with: ");
    }
}
