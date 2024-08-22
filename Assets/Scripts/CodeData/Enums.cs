using System;

public static class Enums
{
    #region -Serializable-

    [Serializable]
    public enum Scenes
    {
        StartScene = 0,
        GameScene = 1, 
        Map = 2,
        Inventory = 3,
        Skills = 4,
        LoadScene = 5,
    }

    [Serializable]
    public enum TypeMapTile
    {
        Unavailable,
        Close,
        Open,
    }

    [Serializable]
    public enum TypeWeapon
    {
        Melee,
        LongRange,
    }

    [Serializable]
    public enum TypeIventSlot
    {
        Equipment,
        Inventory,
    }

    [Serializable]
    public enum TypeEquipment
    {
        MeleeWeapon,
        Shield,
        RangeWeapon,
        Ammunition,
        Helmet,
        Breastplate,
        Pants,
        Boots,
        Potion,
    }

    [Serializable]
    public enum TypeMap
    {
        MiniMap,
        FullMap,
    }


    #endregion

    #region -NonSerializable-

    public enum Axis
    {
        Horizontal,
        Vertical,
    }

    public enum Side
    {
        Top,
        Bottom,
        Left,
        Right,
    }

    #endregion
}