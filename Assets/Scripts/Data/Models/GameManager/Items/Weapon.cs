using Newtonsoft.Json;
using UnityEngine;
using static Enums;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Items/Weapon")]
public class Weapon : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public TypeWeapon typeWeapon;
    public Property<int> damage;
    public Property<float> attackSpeed;

    public Weapon() { }

    public Weapon(TypeWeapon typeWeapon)
    {
        this.typeWeapon = typeWeapon;
    }

    public void SetEquipment()
    {
        if (typeWeapon == TypeWeapon.Melee)
        {
            ResourceManager.s_Instance.Equipment.MeleeWeapon = this;
        }
        else
        {
            ResourceManager.s_Instance.Equipment.RangeWeapon = this;
        }   
    }

    public TypeEquipment GetTypeEquipment()
    {
        return (typeWeapon == TypeWeapon.Melee) ? TypeEquipment.MeleeWeapon : TypeEquipment.RangeWeapon;
    }

    public string GetKey()
    {
        return (typeWeapon == TypeWeapon.Melee) ? Constants.Weapon.PREFSMELEEKEY : Constants.Weapon.PREFSRANGEKEY;
    }

    public string GetDefault()
    {
        return (typeWeapon == TypeWeapon.Melee) ? Constants.Weapon.PREFSMELEEDEFAULT : Constants.Weapon.PREFSRANGEDEFAULT;
    }
}