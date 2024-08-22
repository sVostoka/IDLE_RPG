using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Scriptable Objects/Items/Shield")]
public class Shield : Item, IDatable, IEquipable
{
    [JsonIgnore]
    public dynamic Default => null;

    [Header("Characteristics")]
    public Property<int> armor;

    public void SetEquipment()
    {
        ResourceManager.s_Instance.Equipment.Shield = this;
    }

    public Enums.TypeEquipment GetTypeEquipment()
    {
        return Enums.TypeEquipment.Shield;
    }

    public string GetKey()
    {
        return Constants.Shield.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Shield.PREFSDEFAULT;
    } 
}