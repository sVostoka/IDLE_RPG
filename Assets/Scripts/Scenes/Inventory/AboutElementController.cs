using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class AboutElementController : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    [Header ("Image")]
    [SerializeField] private Image _icon;

    [Header ("Info")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _properies;

    [Header("Use")]
    [SerializeField] private Button _useButton;

    private Item _data;

    private void Awake()
    {
        _closeButton.onClick.AddListener(Hide);
        _useButton.onClick.AddListener(Use);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Use()
    {
        (_data as IUseble).Use();
        Hide();
    }

    public void OpenElement(Item data, Vector3 buttonPosititon, TypeIventSlot typeSlot)
    {
        _data = data;
        gameObject.SetActive(true);

        _icon.sprite = data.icon;

        _name.text = data.name;
        _description.text = data.description;

        string properties = "";

        FieldInfo[] fields = data.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
        {
            Type fieldType = field.FieldType;

            if(fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(Property<>))
            {
                dynamic fieldObj = field.GetValue(data);

                properties += fieldObj.name + ": " + fieldObj.value + "\n";
            }
        }

        _properies.text = properties;

        _useButton.gameObject.SetActive(data.isUsing);
    }
}
