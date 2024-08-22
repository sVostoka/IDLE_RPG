using System;
using UnityEngine;
using static Enums;

[Serializable]
public class MapTile
{
    [SerializeField] public TypeMapTile TypeTile;
    [SerializeField] public int KillCount;
}