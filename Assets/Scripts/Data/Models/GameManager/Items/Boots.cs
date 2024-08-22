using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Boots", menuName = "Scriptable Objects/Items/Boots")]
public class Boots : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header ("Characteristics")]
    public Property<int> armor;

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Boots = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Boots;
    }

    public string GetKey()
    {
        return Constants.Boots.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Boots.PREFSDEFAULT;
    }
}