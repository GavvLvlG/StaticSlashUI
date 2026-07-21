using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   [Header("UI")]
   public Image image;
   public Text countText;


   [HideInInspector] public Transform parentAfterDrag;
   [HideInInspector] public Item item;

   public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        // Ensure the GameObject has a non-empty name. Some Unity versions forbid empty names.
        try
        {
            if (string.IsNullOrEmpty(gameObject.name))
            {
                gameObject.name = newItem != null && !string.IsNullOrEmpty(newItem.name) ? newItem.name : "InventoryItem";
            }
        }
        catch
        {
            // If setting the name fails for any reason, fall back to a safe default via transform.
            if (string.IsNullOrEmpty(transform.name)) transform.name = "InventoryItem";
        }
    }
   public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        countText.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
     {
          transform.position = Input.mousePosition;
     }

    public void OnEndDrag(PointerEventData eventData)
     {
          image.raycastTarget = true;
          countText.raycastTarget = true;
          transform.SetParent(parentAfterDrag);
     }

}

