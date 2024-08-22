using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

public class Level : IDatable
{
    [JsonIgnore]
    dynamic IDatable.Default => new Level(
            Constants.Level.LVLDEFAULT,
            Constants.Level.EXPERIENCEDEFAULT
        );

    #region -LevelValue-
    public event Action ChangeLvlValue;
    private int _value;
    public int Value 
    { 
        get => _value;
        set
        {
            _value = value;

            ChangeLvlValue?.Invoke();
        }
    }
    #endregion

    #region -Experience-

    public int LimitExp { get; set; } = 50;

    public event Action ChangeExperienceValue;

    private int _experience;
    public int Experience
    {
        get => _experience;
        set
        {
            if (value > LimitExp)
            {
                _experience = value - LimitExp;
                Value++;

                UpCharacteristics();
            }
            else
            {
                _experience = value;
            }

            ChangeExperienceValue?.Invoke();
        }
    }

    #endregion

    public Level() { }

    public Level(int value, int experience)
    {
        Value = value;
        Experience = experience;
    }

    private void UpCharacteristics()
    {
        PropertyInfo[] propertiesObj = GameController.s_Instance.CharacterController.Characteristics.GetType().GetProperties();

        List<PropertyInfo> correctProperties = new();
        foreach (var property in propertiesObj) 
        {
            if (property.PropertyType.BaseType.IsGenericType)
            {
                Type genericType = property.PropertyType.BaseType.GetGenericTypeDefinition();

                if (genericType == typeof(Characteristic<>))
                {
                    correctProperties.Add(property);
                }
            }
        }

        int randomIndex = UnityEngine.Random.Range(0, correctProperties.Count - 1);

        ((dynamic)correctProperties[randomIndex].GetValue(GameController.s_Instance.CharacterController.Characteristics)).UpCharacteristic();
    }

    public string GetKey()
    {
        return Constants.Level.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Level.PREFSDEFAULT;
    }
}