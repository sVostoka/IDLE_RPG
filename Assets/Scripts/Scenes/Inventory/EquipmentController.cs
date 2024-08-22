using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private SlotController _meleeWeapon;
    [SerializeField] private SlotController _shield;
    [SerializeField] private SlotController _rangeWeapon;
    [SerializeField] private SlotController _ammunition;
    [SerializeField] private SlotController _helmet;
    [SerializeField] private SlotController _breastplate;
    [SerializeField] private SlotController _pants;
    [SerializeField] private SlotController _boots;

    private void Awake()
    {
        ResourceManager.s_Instance.Equipment.EquipmentChange += SetEquipment;

        SetEquipment();
    }

    private void SetEquipment()
    {
        _meleeWeapon.Data = ResourceManager.s_Instance.Equipment.MeleeWeapon;
        _shield.Data = ResourceManager.s_Instance.Equipment.Shield;
        _rangeWeapon.Data = ResourceManager.s_Instance.Equipment.RangeWeapon;
        _ammunition.Data = ResourceManager.s_Instance.Equipment.Ammunition;
        _helmet.Data = ResourceManager.s_Instance.Equipment.Helmet;
        _breastplate.Data = ResourceManager.s_Instance.Equipment.Breastplate;
        _pants.Data = ResourceManager.s_Instance.Equipment.Pants;
        _boots.Data = ResourceManager.s_Instance.Equipment.Boots;
    }

    private void OnDestroy()
    {
        ResourceManager.s_Instance.Equipment.EquipmentChange -= SetEquipment;
    }
}
