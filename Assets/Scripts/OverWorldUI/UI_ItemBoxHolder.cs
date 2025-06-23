using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemBoxHolder : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject boxPrefab;
    Inventory inventory;
    int position;
    GameObject box;

    public void SetUp(Inventory inventory, int position)
    {
        this.inventory = inventory;
        this.position = position;
        Refresh();
    }

    public void Refresh()
    {
        Destroy(box);
        box = GameObject.Instantiate(boxPrefab, this.transform);
        box.GetComponent<UI_ItemBox>().SetItem(inventory.GetList()[position], position);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped in a Box Holder at position " + position);
        GameObject droped = eventData.pointerDrag;
        UI_ItemBox itemBox = droped.GetComponent<UI_ItemBox>();
        List<InventorySlot> temp = inventory.GetList();
        temp.RemoveAt(itemBox.GetPosition());
        temp.Insert(position, itemBox.Slot());
        inventory.ChangePosition(temp);
        GameObject.Find("InventoryWindow").GetComponent<OverworldUI_ItemsWindow>().Refresh();
        
    }
}
