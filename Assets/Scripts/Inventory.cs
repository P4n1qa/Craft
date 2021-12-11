using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<AssetItem> Items;
    [SerializeField] InventoryItemPresenter inventoryItemPresenter;
    [SerializeField] Transform _container;
    [SerializeField] Transform _draggingParent;

    public void OnEnable()
    {
        Render(Items);
    }
    public void Render(List<AssetItem>items)
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);

        items.ForEach(item =>
        {
            var cell = Instantiate(inventoryItemPresenter, _container);
            cell.Init(_draggingParent);
            cell.Render(item);
        });
    }
}
