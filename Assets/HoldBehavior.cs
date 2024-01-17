using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HoldBehavior : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public GameObject placeholder;
    [HideInInspector] public Vector3 startPosition = Vector3.zero;
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = Instantiate(gameObject, transform.position, Quaternion.identity);
        placeholder.transform.SetParent(transform.parent);
        placeholder.GetComponent<ItemThumbnail>().itemEnable = false;
        gameObject.transform.SetParent(transform.parent.parent.parent);
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(placeholder.transform.parent);
        Destroy(placeholder);
        transform.position = startPosition;
    }
}