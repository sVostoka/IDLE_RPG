using Newtonsoft.Json;
using System;
using UnityEngine;
using static Enums;

public class Map : IDatable
{
    [JsonIgnore]
    public dynamic Default => new Map();

    #region -Map-
    public event Action MapUpdate;

    public MapTile[,] MapTiles { get; set; }
    #endregion

    #region -Position-
    public delegate void UpdatePlayerPosition(Vector2 position);
    public event UpdatePlayerPosition UpdatePosition;

    [JsonProperty]
    private int _xPosition;
    [JsonProperty]
    private int _yPosition;

    [JsonIgnore]
    public Vector2 Position 
    { 
        get => new(_xPosition, _yPosition);
        set 
        {
            _xPosition = (int)value.x;
            _yPosition = (int)value.y;

            UpdatePosition?.Invoke(value);
        } 
    }
    #endregion
    
    public void PlusKill()
    {
        MapTiles[(int)Position.x, (int)Position.y].KillCount++;

        if (MapTiles[(int)Position.x, (int)Position.y].KillCount == ResourceManager.s_Instance.Map[(int)Position.x, (int)Position.y].NeedKill)
        {
            int[,] directions = new int[,]
            {
                { -1, 0 },
                { 1, 0 },
                { 0, -1 },
                { 0, 1 }
            };

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newX = (int)Position.x + directions[i, 0];
                int newY = (int)Position.y + directions[i, 1];

                if (newX >= 0 && newX < MapTiles.GetLength(0) && newY >= 0 && newY < MapTiles.GetLength(1)) 
                {
                    if((newX != (int)Position.x || newY != (int)Position.y) && MapTiles[newX, newY].TypeTile != TypeMapTile.Unavailable)
                    {
                        MapTiles[newX, newY].TypeTile = TypeMapTile.Open;
                    }
                }
            }
        }

        MapUpdate?.Invoke();
    }

    public string GetKey()
    {
        return Constants.Map.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Map.PREFSDEFAULT;
    }
}