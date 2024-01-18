using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    [SerializeField] public Head headEquip;
    [SerializeField] public Body bodyEquip;
    [SerializeField] public Weapon weaponEquip;

    public void SetHead(Head item)
    {
        headEquip = item;
    }

    public void SetBody(Body item)
    {
        bodyEquip = item;
    }

    public void SetWeapon(Weapon item)
    {
        weaponEquip = item;
    }
}
