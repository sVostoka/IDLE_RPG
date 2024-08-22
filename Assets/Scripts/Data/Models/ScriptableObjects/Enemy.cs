using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : ScriptableObject, IProbability, ICloneable
{
    [Header ("Probability")]
    public float probability;
    public float Probability { get => probability; set => probability = value; }

    [Header ("Characteristics")]
    public int armor;
    public int health;
    public int damage;
    public float preparation;
    public float attackSpeed;

    [Header("Loot")]
    public int experience;
    public List<Item> loot;

    [Header("Image")]
    public Image icon;
    public Image model;

    public object Clone()
    {
        return MemberwiseClone() as Enemy;
    }
}
