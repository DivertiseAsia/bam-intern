using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "SavePlayerData", menuName = "Project Exclusive/Player Data/Save")]
public class SavePlayerData : ScriptableObject
{
    public int accountId;
    public string accName;
    public string message;
    [TextArea] public string wallet;
    public List<Item> owned;
    public Head playerHeadEquip;
    public Body playerBodyEquip;
    public Weapon playerWeaponEquip;

    public string countOnBanner;

    public SavePlayerData()
    {
        accountId = 0;
        accName = "Player" + accountId;
        message = "";
        wallet = JsonUtility.ToJson(new Wallet());
        owned = new List<Item>();
        countOnBanner = JsonUtility.ToJson(new CountList());
    }
}
