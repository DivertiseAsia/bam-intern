using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerEquip : MonoBehaviour
{
    [SerializeField] public Head headEquip;
    [SerializeField] public Body bodyEquip;
    [SerializeField] public Weapon weaponEquip;

    public void Update()
    {
        if (headEquip == null)
        {
            headEquip = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Script/ScriptableObject/nullHat.prefab", typeof(GameObject))).GetComponent<Head>();
        }

        if (bodyEquip == null)
        {
            bodyEquip = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Script/ScriptableObject/nullBody.prefab", typeof(GameObject))).GetComponent<Body>();
        }

        if (weaponEquip == null)
        {
            weaponEquip = ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Script/ScriptableObject/nullWeapon.prefab", typeof(GameObject))).GetComponent<Weapon>();
        }
    }

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
