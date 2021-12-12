using System.Collections.Generic;
using UnityEngine;

public class IteamCraft : MonoBehaviour
{
    [SerializeField] AssetItem result;
    [SerializeField] List<AssetItem> itemsNeeded, inventoryItems;
    [SerializeField] Inventory inventory;

    private int _countNeed;

    public void Craft()
    {
        _countNeed = itemsNeeded.Count;
        inventoryItems = inventory.GetItemsInInventory();
        foreach (AssetItem itemNeeded in itemsNeeded)
        {
            foreach (AssetItem itemToFound in inventoryItems)
            {
                if (itemNeeded.Id == itemToFound.Id)
                {
                    _countNeed--;
                }
            }
        }
        if (_countNeed == 0)
        {
            inventory.AddItem(result);
            foreach (AssetItem itemNeeded in itemsNeeded)
            {
                for (int i = 0; i < inventoryItems.Count; i++)
                {
                    if (itemNeeded.Id == inventoryItems[i].Id)
                    {
                        inventory.RemoveItem(inventoryItems[i]);
                    }
                }
            }
        }
    }
}
