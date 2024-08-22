using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Breastplate", menuName = "Scriptable Objects/Items/Breastplate")]
public class Breastplate : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public Property<int> armor;

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Breastplate = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Breastplate;
    }
    public string GetKey()
    {
        return Constants.Breastplate.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Breastplate.PREFSDEFAULT;
    }
}