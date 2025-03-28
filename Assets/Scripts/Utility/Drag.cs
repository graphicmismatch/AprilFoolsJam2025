using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(ClothingObject))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag;
    private CanvasGroup canvasGroup;
    private Slot slot;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        GetComponent<ClothingObject>().ToggleVisibility(true);
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        resetSlotPosition();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var d = eventData.pointerDrag.GetComponent<Drag>();
        if (slot != null && d.slot != null)
        {
            var a = slot;
            var b = d.getSlot();
            d.clearPrevSlot();
            clearPrevSlot();
            setSlot(b);
            d.setSlot(a);
        }
    }



    public void clearPrevSlot()
    {
        if (!slot) { return; }
        slot.item = null;
        slot = null;
    }
    public void resetSlotPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = slot.GetComponent<RectTransform>().anchoredPosition;
        if(slot != null)
        {
            GetComponent<ClothingObject>().ToggleVisibility(!slot.hideItem);
        }
    }

    public void setSlot(Slot s)
    {
        clearPrevSlot();
        slot = s;
        slot.item = GetComponent<ClothingObject>();
        resetSlotPosition();
    }

    public Slot getSlot()
    {
        return slot;
    }
}
