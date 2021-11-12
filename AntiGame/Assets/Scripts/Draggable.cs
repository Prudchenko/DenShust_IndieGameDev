using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CompareTag("Draggable"))
        {
            // Debug.Log("Begin Drag");
            canvasGroup.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (CompareTag("Draggable"))
        {
            // Debug.Log("Dragging ...");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("End Drag");
        if (CompareTag("Draggable"))
        {

            canvasGroup.blocksRaycasts = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (CompareTag("Draggable"))
        {
            rectTransform.SetAsLastSibling();
            canvasGroup.alpha = 0.6f;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
    }
}
