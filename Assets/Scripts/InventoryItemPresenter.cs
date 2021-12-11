using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
    public class InventoryItemPresenter: MonoBehaviour , IDragHandler , IEndDragHandler , IBeginDragHandler
    {
    [SerializeField] Text _nameField;
    [SerializeField] Image _iconField;

    private Transform _draggingParent;
    private Transform _originalParent;

    public void Init(Transform draggingParent)
    {
        _draggingParent = draggingParent;
        _originalParent = transform.parent;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int closestIndex = 0;
        for (int i =0;i< _originalParent.transform.childCount; i++)
        {
            if(Vector3.Distance(transform.position,_originalParent.GetChild(i).position)<
               Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
            {
                closestIndex = 1;
            }
        }
        transform.parent = _originalParent;
        transform.SetSiblingIndex(closestIndex);
    }

    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }

}
