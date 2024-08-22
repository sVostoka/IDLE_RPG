public static class Constants
{
    public static class Map
    {
        public static string PREFSKEY = "Map";
        public static string PREFSDEFAULT = "";
    }

    public static class Level
    {
        public static string PREFSKEY = "Level";
        public static string PREFSDEFAULT = "";

        public static int LVLDEFAULT = 0;
        public static int EXPERIENCEDEFAULT = 0;
    }

    #region -Characteristics-
    public static class Characteristics
    {
        public static string PREFSKEY = "Characteristics";
        public static string PREFSDEFAULT = "";

        public static int ARMORDEFAULT = 0;
        public static int HEALTHDEFAULT = 10;
        public static int DAMAGEDEFAULT = 1;
        public static float PREPARATIONDEFAULT = 2;
        public static float ATTACKSPEEDDEFAULT = 2;
    }

    public static class Characteristic
    {
        public static string ARMORNAME = "Броня";
        public static string HEALTHNAME = "Здоровье";
        public static string DAMAGENAME = "Урон";
        public static string PREPARATIONNAME = "Подготовка к удару";
        public static string ATTACKSPEEDNAME = "Скорость атаки";

    }

    #endregion

    public static class Inventory
    {
        public static string PREFSKEY = "Inventory";
        public static string PREFSDEFAULT = "";
    }

    #region -Items-
    public static class Weapon 
    {
        public static string PREFSMELEEKEY = "WeaponMelee";
        public static string PREFSMELEEDEFAULT = "";

        public static string PREFSRANGEKEY = "WeaponRange";
        public static string PREFSRANGEDEFAULT = "";
    }
    public static class Shield
    {
        public static string PREFSKEY = "Shield";
        public static string PREFSDEFAULT = "";
    }

    public static class Ammunition
    {
        public static string PREFSKEY = "Ammunition";
        public static string PREFSDEFAULT = "";
    }

    public static class Helmet
    {
        public static string PREFSKEY = "Helmet";
        public static string PREFSDEFAULT = "";
    }    

    public static class Breastplate
    {
        public static string PREFSKEY = "Breastplate";
        public static string PREFSDEFAULT = "";
    }

    public static class Pants
    {
        public static string PREFSKEY = "Pants";
        public static string PREFSDEFAULT = "";
    }

    public static class Boots 
    {
        public static string PREFSKEY = "Boots";
        public static string PREFSDEFAULT = "";
    }
    #endregion
}