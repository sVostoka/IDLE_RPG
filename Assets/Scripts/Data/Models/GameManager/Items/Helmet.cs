using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "Scriptable Objects/Items/Helmet")]
public class Helmet : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public Property<int> armor;

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Helmet = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Helmet;
    }
    public string GetKey()
    {
        return Constants.Helmet.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Helmet.PREFSDEFAULT;
    }
}