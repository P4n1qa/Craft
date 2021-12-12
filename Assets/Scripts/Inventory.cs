using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<AssetItem> Items;
    [SerializeField] InventoryItemPresenter inventoryItemPresenter;
    [SerializeField] Transform container;
    [SerializeField] Transform draggingParent;

    public void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetItem>items)
    {
        foreach (Transform child in container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(inventoryItemPresenter, container);
            cell.Init(draggingParent);
            cell.Render(item);
        });
 
    }
    public List<AssetItem> GetItemsInInventory()
    {
        return Items;
    }
    public void RemoveItem(AssetItem item)
    {
        Items.Remove(item);
        Render(Items);
    }
    public void AddItem(AssetItem item)
    {
        Items.Add(item);
        Render(Items);
    }
}
