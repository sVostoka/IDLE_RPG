using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Enums;

public class SlotController : MonoBehaviour, IDropHandler
{
    [SerializeField] private AboutElementController _aboutElement;
    private Button _aboutButton;

    [SerializeField] private ItemController _itemController;
    [SerializeField] private TypeIventSlot _typeSlot;
    [SerializeField] private TypeEquipment _typeEquipnemt;
    public TypeIventSlot TypeSlot { get => _typeSlot; }

    private Item _data = null;
    public Item Data 
    { 
        get => _data;
        set 
        {
            _data = value;

            if (value != null) 
            {
                ShowItem(); 
            }
            else
            {
                HideItem();
            }

        }
    }

    private void SetListener()
    {
        _aboutButton = GetComponent<Button>();

        _aboutButton.onClick.AddListener(delegate
        {
            _aboutElement.OpenElement(Data, _aboutButton.transform.position, TypeSlot);
        });
    }

    private void ShowItem()
    {
        SetListener();
        _itemController.gameObject.SetActive(true);
        _itemController.SetData(Data);
    }

    private void HideItem()
    {
        _itemController.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(TypeSlot == TypeIventSlot.Equipment)
        {
            SlotController dragSlot = eventData.pointerDrag.GetComponent<ItemController>().CurrentSlot;

            if (typeof(IEquipable).IsAssignableFrom(dragSlot.Data.GetType()))
            {
                Item dragData = dragSlot.Data;

                if (((IEquipable)dragData).GetTypeEquipment() == _typeEquipnemt)
                {
                    if (((IEquipable)dragData).GetTypeEquipment() != TypeEquipment.Ammunition)
                    {
                        if (((IEquipable)dragData).GetTypeEquipment() == TypeEquipment.RangeWeapon)
                        {
                            ResourceManager.s_Instance.Equipment.Ammunition?.InInventory();
                            ResourceManager.s_Instance.Equipment.Ammunition = null;
                        }

                        Equip(dragSlot, dragData);
                    }
                    else if (ResourceManager.s_Instance.Equipment.RangeWeapon != null)
                    {
                        if (((Ammunition)dragData).suitableWeapon.name == ResourceManager.s_Instance.Equipment.RangeWeapon.name)
                        {
                            Equip(dragSlot, dragData);
                        }
                    }
                }
            }
        }
    }

    private void Equip(SlotController dragSlot, Item dragData)
    {
        if (Data == null)
        {
            ResourceManager.s_Instance.Inventory.DeleteItem(dragData, true);
        }
        else
        {
            ResourceManager.s_Instance.Inventory.DeleteItem(dragData, true);
            ResourceManager.s_Instance.Inventory.AddItem(Data);
        }

        ((IEquipable)dragData).SetEquipment();
    }
}
