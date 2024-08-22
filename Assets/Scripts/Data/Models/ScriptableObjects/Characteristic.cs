using System;
using UnityEngine;
using static Constants;

public abstract class Characteristic<T>
{
    [SerializeField] private string _name;

    public string Name { get => _name; set => _name = value; }

    [SerializeField] private T _value;

    public T Value { get => _value; set => _value = value; }

    public abstract void UpCharacteristic();
}

[Serializable]
public class Armor : Characteristic<int>
{
    public Armor(int value) 
    {
        Name = Characteristic.ARMORNAME;
        Value = value;
    }

    public override void UpCharacteristic()
    {
        Value++;
    }
}

[Serializable]
public class Health : Characteristic<int>
{
    public delegate void HealthValueDelegate(int value);
    public event HealthValueDelegate UpdateValue;
    public Health(int value)
    {
        Name = Characteristic.HEALTHNAME;
        Value = value;
    }

    public override void UpCharacteristic()
    {
        Value += 2;
        UpdateValue?.Invoke(Value);
    }
}

[Serializable]
public class Damage : Characteristic<int>
{
    public Damage(int value)
    {
        Name = Characteristic.DAMAGENAME;
        Value = value;
    }

    public override void UpCharacteristic()
    {
        Value++;
    }
}

[Serializable]
public class Preparation : Characteristic<float>
{
    public Preparation(float value)
    {
        Name = Characteristic.PREPARATIONNAME;
        Value = value;
    }

    public override void UpCharacteristic()
    {
        if(Value > 0.5) Value -= 0.1f;
    }
}

[Serializable]
public class AttackSpeed : Characteristic<float>
{
    public AttackSpeed(float value)
    {
        Name = Characteristic.ATTACKSPEEDNAME;
        Value = value;
    }

    public override void UpCharacteristic()
    {
        if (Value > 0.5) Value -= 0.1f;
    }
}