using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayPlayerEquip : MonoBehaviour,  IDropHandler
{
    PlayerEquip playerEquip => FindObjectOfType<PlayerEquip>();
    [SerializeField] ItemThumbnail headThumbnail;
    [SerializeField] ItemThumbnail bodyThumbnail;
    [SerializeField] ItemThumbnail weaponThumbnail;

    public void Update()
    {
        headThumbnail.itemTemplate = playerEquip.headEquip.GetTemplate();
        bodyThumbnail.itemTemplate = playerEquip.bodyEquip.GetTemplate();
        weaponThumbnail.itemTemplate = playerEquip.weaponEquip.GetTemplate();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemThumbnail dragged = eventData.pointerDrag.GetComponent<ItemThumbnail>();

        if ((int)dragged.itemTemplate.itemType == (int)ItemType.head)
        {
            playerEquip.SetHead(dragged.itemTemplate.itemRef.GetComponent<Head>());
        }

        else if ((int)dragged.itemTemplate.itemType == (int)ItemType.body)
        {
            playerEquip.SetBody(dragged.itemTemplate.itemRef.GetComponent<Body>());
        }

        else if ((int)dragged.itemTemplate.itemType == (int)ItemType.weapon)
        {
            playerEquip.SetWeapon(dragged.itemTemplate.itemRef.GetComponent<Weapon>());
        }
    }
}
