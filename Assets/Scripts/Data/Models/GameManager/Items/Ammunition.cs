using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammunition", menuName = "Scriptable Objects/Items/Ammunition")]
public class Ammunition : Item, IDatable, IEquipable, IUseble
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public Weapon suitableWeapon;
    public Property<int> damage;

    public void Use()
    {
        count--;
        if(count == 0)
        {
            ResourceManager.s_Instance.Equipment.Ammunition = null;
        }
    }

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Ammunition = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Ammunition;
    }

    public string GetKey()
    {
        return Constants.Ammunition.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Ammunition.PREFSDEFAULT;
    }
}