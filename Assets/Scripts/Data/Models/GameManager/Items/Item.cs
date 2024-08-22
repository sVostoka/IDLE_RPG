using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Item : ScriptableObject, IProbability, ICloneable
{
    [Header ("Info")]
    public new string name;
    public string description;

    [JsonIgnore]
    public Sprite icon;
    public string IconPath
    {
        get
        {
            return icon.name;
        }
        set
        {
            List<Sprite> sprites = Resources.LoadAll<Sprite>("Image/Items").ToList();

            icon = sprites.Find(x => x.name == value);
        }
    }

    [Header("Probability")]
    [JsonIgnore]
    public float probability;
    public float Probability { get => probability; set => probability = value; }

    [Header("Combination")]
    public bool isCombined;
    public int count;
    public int maxCombination;

    [Header("Use")]
    public bool isUsing = false;

    public void InInventory()
    {
        ResourceManager.s_Instance.Inventory.AddItem(this);
    }

    public object Clone()
    {
        return MemberwiseClone() as Item;
    }
}