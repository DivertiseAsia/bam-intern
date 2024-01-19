using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldBehavior : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
     public Image touchArea;
    [HideInInspector] public GameObject placeholder;
    [HideInInspector] public Vector3 startPosition = Vector3.zero;
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = Instantiate(gameObject, transform.position, Quaternion.identity);
        placeholder.transform.SetParent(transform.parent);
        placeholder.GetComponent<ItemThumbnail>().itemEnable = false;
        transform.SetParent(transform.parent.parent.parent);
        transform.SetAsLastSibling();
        startPosition = transform.position;
        touchArea.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(placeholder.transform.parent);
        transform.position = startPosition;
        touchArea.raycastTarget = true;
        StartCoroutine("DelayedDestroy");
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(placeholder);
    }
}