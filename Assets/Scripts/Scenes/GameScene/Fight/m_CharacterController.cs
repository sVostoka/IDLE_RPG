using System;
using UnityEngine;
using static Enums;

public class m_CharacterController : Hero
{
    public event Action ChangeTypeAttack;

    private TypeWeapon _typeAttack;
    public TypeWeapon TypeAttack 
    { 
        get => _typeAttack;
        set
        {
            _typeAttack = value;

            ChangeTypeAttack?.Invoke();
        } 
    }

    public int Armor
    {
        get
        {
            Equipment equipment = ResourceManager.s_Instance.Equipment;

            int armor = 0;

            armor += (equipment.Helmet == null) ? 0 : equipment.Helmet.armor.value;
            armor += (equipment.Breastplate == null) ? 0 : equipment.Breastplate.armor.value;
            armor += (equipment.Pants == null) ? 0 : equipment.Pants.armor.value;
            armor += (equipment.Boots == null) ? 0 : equipment.Boots.armor.value;

            if (TypeAttack == TypeWeapon.Melee)
            {
                armor += (equipment.Shield == null) ? 0 : equipment.Shield.armor.value;
            }

            return armor + Characteristics.Armor.Value;
        }
    }

    public int Damage
    {
        get
        {
            Equipment equipment = ResourceManager.s_Instance.Equipment;

            if (TypeAttack == TypeWeapon.Melee)
            {
                if (equipment.MeleeWeapon == null)
                {
                    return Characteristics.Damage.Value;
                }
                else
                {
                    return equipment.MeleeWeapon.damage.value + Characteristics.Damage.Value;
                }
            }
            else
            {
                if (equipment.Ammunition == null)
                {
                    return Characteristics.Damage.Value;
                }
                else
                {
                    equipment.Ammunition.Use();

                    return (equipment.Ammunition == null) ? 0 : equipment.Ammunition.damage.value + Characteristics.Damage.Value;
                }
            }
        }
    }

    public float AttackSpeed
    {
        get
        {
            if (TypeAttack == TypeWeapon.Melee)
            {
                if (ResourceManager.s_Instance.Equipment.MeleeWeapon == null)
                {
                    return Characteristics.AttackSpeed.Value;
                }
                else
                {
                    return ResourceManager.s_Instance.Equipment.MeleeWeapon.attackSpeed.value;
                }                
            }
            else
            {
                if (ResourceManager.s_Instance.Equipment.RangeWeapon == null)
                {
                    return Characteristics.AttackSpeed.Value;
                }
                else
                {
                    return ResourceManager.s_Instance.Equipment.RangeWeapon.attackSpeed.value;
                }
            }
        }
    }

    [SerializeField] private Characteristics _characteristics;
    public Characteristics Characteristics { get => _characteristics; private set => _characteristics = value; }

    private void Awake()
    {
        SetCharacteristics();

        _hpController.SetHP(Characteristics.Health.Value, Characteristics.Health.Value);

        MaxHP = Characteristics.Health.Value;
        HP = Characteristics.Health.Value;

        Characteristics.Health.UpdateValue += UpdateMaxHealth;
    }

    private void OnDestroy()
    { 
        Characteristics.Health.UpdateValue -= UpdateMaxHealth;
    }

    private void UpdateMaxHealth(int health)
    {
        MaxHP = health;
        _hpController.SetHP(HP, health);
    }

    private void SetCharacteristics()
    {
        Characteristics.Armor = ResourceManager.s_Instance.Characteristics.Armor;
        Characteristics.Health = ResourceManager.s_Instance.Characteristics.Health;
        Characteristics.Damage = ResourceManager.s_Instance.Characteristics.Damage;
        Characteristics.Preparation = ResourceManager.s_Instance.Characteristics.Preparation;
        Characteristics.AttackSpeed = ResourceManager.s_Instance.Characteristics.AttackSpeed;
    }

    protected override void Dead()
    {
        //TODO можно наложить штраф

        base.Dead();
    }
}