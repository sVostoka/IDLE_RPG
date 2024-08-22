using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Scriptable Objects/Characteristics")]
public class Characteristics : ScriptableObject, IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Characteristics(
            new Armor(Constants.Characteristics.ARMORDEFAULT),
            new Health(Constants.Characteristics.HEALTHDEFAULT),
            new Damage(Constants.Characteristics.DAMAGEDEFAULT),
            new Preparation(Constants.Characteristics.PREPARATIONDEFAULT),
            new AttackSpeed(Constants.Characteristics.ATTACKSPEEDDEFAULT)
        );

    [JsonIgnore]
    [SerializeField] private Armor _armor;
    public Armor Armor { get => _armor; set => _armor = value; }

    [JsonIgnore]
    [SerializeField] private Health _health;
    public Health Health {  get => _health; set => _health = value; }

    [JsonIgnore]
    [SerializeField] private Damage _damage;
    public Damage Damage { get => _damage; set => _damage = value; }

    [JsonIgnore]
    [SerializeField] private Preparation _preparation;
    public Preparation Preparation { get => _preparation; set => _preparation = value; }

    [JsonIgnore]
    [SerializeField] private AttackSpeed _attackSpeed;
    public AttackSpeed AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }

    public Characteristics() { }

    public Characteristics(Armor armor, Health health, Damage damage, Preparation preparation, AttackSpeed attackSpeed)
    {
        Armor = armor;
        Health = health;
        Damage = damage;
        Preparation = preparation;
        AttackSpeed = attackSpeed;
    }

    public string GetKey()
    {
        return Constants.Characteristics.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Characteristics.PREFSDEFAULT;
    }
}