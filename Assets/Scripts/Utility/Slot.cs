using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public ClothingObject item;
    public bool hideItem;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<Drag>().setSlot(this);
            if (eventData.pointerDrag.GetComponent<ClothingObject>())
            {
                item = eventData.pointerDrag.GetComponent<ClothingObject>();
            }
        }
    }
}
