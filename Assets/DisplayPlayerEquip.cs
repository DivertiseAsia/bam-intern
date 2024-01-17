using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DisplayPlayerEquip : MonoBehaviour
{
    PlayerEquip playerEquipment => FindObjectOfType<PlayerEquip>();
    [SerializeField] ItemThumbnail headThumbnail;
    [SerializeField] ItemThumbnail bodyThumbnail;
    [SerializeField] ItemThumbnail weaponThumbnail;

    [SerializeField] Image touchArea;

    private void Update()
    {
        CheckItem();
        if (playerEquipment == null) return;

        headThumbnail.itemTemplate = playerEquipment.headEquip.GetTemplate();
        bodyThumbnail.itemTemplate = playerEquipment.bodyEquip.GetTemplate();
        weaponThumbnail.itemTemplate = playerEquipment.weaponEquip.GetTemplate();
    }

    private void CheckItem()
    {
        ItemTemplateScriptableObject targetTemp = null;
        Collider2D[] colli = Physics2D.OverlapBoxAll(touchArea.sprite.bounds.center, touchArea.sprite.bounds.size, 0);
        foreach (Collider2D col in colli)
        {
            if (!col.TryGetComponent<ItemThumbnail>(out ItemThumbnail item))
            {
                targetTemp = col.GetComponent<ItemThumbnail>().itemTemplate;
                break;
            }
        }

        if (targetTemp == null) return;

        switch ((int)targetTemp.itemType)
        {
            case ((int)ItemType.head):
                playerEquipment.headEquip.SetTemplate(targetTemp);
                break;
            case ((int)ItemType.body):
                playerEquipment.bodyEquip.SetTemplate(targetTemp);
                break;
            case ((int)ItemType.weapon):
                playerEquipment.weaponEquip.SetTemplate(targetTemp);
                break;
        }
    }
}
