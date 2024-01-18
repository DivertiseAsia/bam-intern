using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayPlayerEquip : MonoBehaviour, IDropHandler
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
        throw new System.NotImplementedException();
    }
}
