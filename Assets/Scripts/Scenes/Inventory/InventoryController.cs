using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;

    [SerializeField] private GameObject _slotsObject;

    private int _currentPage = 1;
    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;

            SetData();
        }
    }

    private List<Item> _invetory;

    private List<SlotController> _slotsList;
    private int _countItems;
    private int _countPage;

    private void Awake()
    {
        ResourceManager.s_Instance.Inventory.UpdateIventory += SetData;

        _previousButton.onClick.AddListener(BackPage);
        _nextButton.onClick.AddListener(FrontPage);

        _slotsList = _slotsObject.GetComponentsInChildren<SlotController>().ToList();
        _countItems = _slotsList.Count;

        _invetory = ResourceManager.s_Instance.Inventory.Items;

        _countPage = (int)Math.Ceiling((float)_invetory.Count / _countItems);

        if (_countPage <= 1)
        {
            _previousButton.interactable = false;
            _nextButton.interactable = false;
        }

        SetData();
    }

    private void OnDestroy()
    {
        ResourceManager.s_Instance.Inventory.UpdateIventory -= SetData;
    }

    private void BackPage()
    {
        CurrentPage = (CurrentPage - 1 <= 0) ? _countPage : CurrentPage - 1;
    }

    private void FrontPage()
    {
        CurrentPage = (CurrentPage + 1 > _countPage) ? 1 : CurrentPage + 1;
    }

    private void SetData()
    {
        _invetory = ResourceManager.s_Instance.Inventory.Items;

        int start = (_currentPage - 1) * _countItems;

        _slotsList.ForEach(slot => slot.Data = null);

        for (int invIter = start, itemsIter = 0; invIter < _invetory.Count && itemsIter < _countItems; invIter++, itemsIter++)
        {
            _slotsList[itemsIter].Data = _invetory[invIter];
        }
    }

    public void DeleteInventory(Item deleteItem)
    {
        ResourceManager.s_Instance.Inventory.DeleteItem(deleteItem);
    }

    public void AddInventory(Item addItem)
    {
        ResourceManager.s_Instance.Inventory.AddItem(addItem);
    }

    public void SwapItemsInInventory(Item deleteItem, Item addItem)
    {
        DeleteInventory(deleteItem);
        AddInventory(addItem);
    }
}
