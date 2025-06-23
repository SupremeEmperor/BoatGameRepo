using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldUI_ItemsWindow : MonoBehaviour
{
    [SerializeField] GameObject itemBoxHolder;
    [SerializeField] GameObject content;

    InformationHolder informationHolder;
    Inventory inventory;
    List<GameObject> imediatChildren;

    private void Awake()
    {
        imediatChildren = new List<GameObject>();

        informationHolder = GameObject.Find("InformationHolder").GetComponent<InformationHolder>();

        inventory = informationHolder.Inventory();

        PlaceBlocks();

    }

    public void PlaceBlocks()
    {
        List<InventorySlot> inventoryList = inventory.GetList();

        for(int i = 0; i < inventoryList.Count; i++)
        {
            
            GameObject block = GameObject.Instantiate(itemBoxHolder, content.transform);
            imediatChildren.Add(block);
            block.GetComponent<UI_ItemBoxHolder>().SetUp(inventory, i);

        }
    }

    public void Refresh()
    {
        foreach (GameObject block in imediatChildren)
        {
            block.GetComponent<UI_ItemBoxHolder>().Refresh();
        }
    }

}
