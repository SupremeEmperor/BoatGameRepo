using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ItemBox : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemAmnt;
    InventorySlot slot;
    int position;
    Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        this.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        this.GetComponent<Image>().raycastTarget = true;
    }


    
    public void SetItem(InventorySlot slot, int position)
    {
        this.slot = slot;
        this.position = position;
        image.sprite = slot.Sprite();
        itemName.text = slot.ItemName();
        itemAmnt.text = "Amnt: " + slot.Quantity();

    }

    
    public int GetPosition()
    {
        return position;
    }

    public InventorySlot Slot()
    {
        return slot;
    }

    
    public Transform ParentAfterDrag()
    {
        return parentAfterDrag;
    }

    public Transform ParentAfterDrag(Transform parentAfterDrag)
    {
        this.parentAfterDrag = parentAfterDrag;
        return parentAfterDrag;
    }
    
}
