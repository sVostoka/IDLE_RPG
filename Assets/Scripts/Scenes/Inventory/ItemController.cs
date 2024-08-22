using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Enums;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _count;

    public SlotController CurrentSlot { get; private set; }

    public Item Data { get; private set; }

    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        CurrentSlot = GetComponentInParent<SlotController>();

        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetData(Item data)
    {
        Data = data;
        SetImage();
        SetCount();
    }

    public void SetImage()
    {
       _icon.sprite = Data.icon;
    }

    public void SetCount()
    {
        if (Data.isCombined)
        {
            _count.text = Data.count.ToString();
            _count.gameObject.SetActive(true);
        }
        else
        {
            _count.gameObject.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeIventSlot.Inventory)
        {
            transform.SetParent(_canvas.transform);
            BlockRayCast(false);
        }
    }

    #region Drag
    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeIventSlot.Inventory)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (CurrentSlot.TypeSlot == TypeIventSlot.Inventory)
        {
            transform.SetParent(CurrentSlot.transform);
            transform.localPosition = Vector3.zero;
            BlockRayCast(true);
        }
    }

    private void BlockRayCast(bool block)
    {
        _canvasGroup.blocksRaycasts = block;
        _icon.raycastTarget = block;
    }
    #endregion
}
