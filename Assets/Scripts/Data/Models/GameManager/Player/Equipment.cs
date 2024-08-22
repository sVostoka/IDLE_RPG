using System;

public class Equipment
{
    public event Action EquipmentChange;

    private Weapon _meleeWeapon;
    public Weapon MeleeWeapon { get => _meleeWeapon; set { _meleeWeapon = value; EquipmentChange?.Invoke(); } }

    private Shield _shield;
    public Shield Shield { get => _shield; set { _shield = value; EquipmentChange?.Invoke(); } }

    private Weapon _rangeWeapon;
    public Weapon RangeWeapon { get => _rangeWeapon; set { _rangeWeapon = value; EquipmentChange?.Invoke(); } }

    private Ammunition _ammunition;
    public Ammunition Ammunition { get => _ammunition; set { _ammunition = value; EquipmentChange?.Invoke(); } }

    private Helmet _helmet;
    public Helmet Helmet { get => _helmet; set { _helmet = value; EquipmentChange?.Invoke(); } }

    private Breastplate _breastplate;
    public Breastplate Breastplate { get => _breastplate; set { _breastplate = value; EquipmentChange?.Invoke(); } }

    private Pants _pants;
    public Pants Pants { get => _pants; set { _pants = value; EquipmentChange?.Invoke(); }}

    private Boots _boots;
    public Boots Boots { get => _boots; set { _boots = value; EquipmentChange?.Invoke(); } }

    public static Equipment GetData()
    {
        Equipment result = new();

        result.MeleeWeapon = PrefsManager.GetData<Weapon>(new(Enums.TypeWeapon.Melee));
        result.Shield = PrefsManager.GetData<Shield>();

        result.RangeWeapon = PrefsManager.GetData<Weapon>(new(Enums.TypeWeapon.LongRange));
        result.Ammunition = PrefsManager.GetData<Ammunition>();

        result.Helmet = PrefsManager.GetData<Helmet>();
        result.Breastplate = PrefsManager.GetData<Breastplate>();
        result.Pants = PrefsManager.GetData<Pants>();
        result.Boots = PrefsManager.GetData<Boots>();

        return result;
    }

    public bool SetDataPrefs()
    {
        try
        {
            PrefsManager.SetData(MeleeWeapon);
            PrefsManager.SetData(Shield);

            PrefsManager.SetData(RangeWeapon);
            PrefsManager.SetData(Ammunition);

            PrefsManager.SetData(Helmet);
            PrefsManager.SetData(Breastplate);
            PrefsManager.SetData(Pants);
            PrefsManager.SetData(Boots);

            return true;
        }
        catch
        {
            return false;
        }
    }
}