using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Pants", menuName = "Scriptable Objects/Items/Pants")]
public class Pants : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public Property<int> armor;

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Pants = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Pants;
    }

    public string GetKey()
    {
        return Constants.Pants.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Pants.PREFSDEFAULT;
    }
}