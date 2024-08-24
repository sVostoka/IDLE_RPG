using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager s_Instance { get; private set; }

    [SerializeField] private bool _deletePrefs = false;

    #region -Time-
    private float _timeScale;
    public float TimeScale
    {
        get => _timeScale;
        set
        {
            _timeScale = value;
            Time.timeScale = _timeScale;
        }
    }
    #endregion

    #region -Player-
    public Level Level { get; private set; }

    public Characteristics Characteristics { get; private set; }

    public Inventory Inventory { get; private set; }

    public Equipment Equipment { get; private set; }

    //public Skills Skills { get; private set; }
    #endregion

    #region -Map-
    public Map MapData { get; private set; }

    public MapTileController [,] Map {  get; private set; }
    #endregion

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else if (s_Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (_deletePrefs)
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {
            InitializeManager();
        }
    }

    private void InitializeManager()
    {
        Level = PrefsManager.GetData<Level>();
        Characteristics = PrefsManager.GetData<Characteristics>();

        Inventory = PrefsManager.GetData<Inventory>();
        Equipment = Equipment.GetData();

        ScenesManager.LoadScene(Scenes.Map, loadSceneMode: LoadSceneMode.Additive);
        ScenesManager.LoadScene(Scenes.LoadScene, loadSceneMode: LoadSceneMode.Additive);
    }

    private void Start()
    {
        FindFirstObjectByType<MapController>().Update += SetMap;
    }

    private void OnApplicationPause()
    {
        SaveAll();
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    private void SetMap(MapTileController[,] mapTiles, MapTile[,] mapData, Vector2 startPosition)
    {
        MapData = PrefsManager.GetData<Map>();

        if(MapData.MapTiles == null)
        {
            MapData.MapTiles = new MapTile[mapData.GetLength(0), mapData.GetLength(1)];
            MapData.MapTiles = (MapTile[,])mapData.Clone();
            MapData.Position = startPosition;
        }

        Map = mapTiles;

        FindFirstObjectByType<MapController>().Update -= SetMap;

        ScenesManager.LoadScene(Scenes.GameScene);
    }

    #region -SaveData-
    private void SaveAll()
    {
        SaveLevel();
        SaveCharacteristics();
        SaveInventory();
        SaveEquipment();
        SaveMap();
    }

    private void SaveLevel()
    {
        PrefsManager.SetData(Level);
    }

    private void SaveCharacteristics()
    {
        PrefsManager.SetData(GameController.s_Instance.CharacterController.Characteristics);
    }

    private void SaveEquipment()
    {
        Equipment.SetDataPrefs();
    }

    private void SaveInventory()
    {
        PrefsManager.SetData(Inventory);
    }

    private void SaveMap()
    {
        PrefsManager.SetData(MapData);
    }
    #endregion
}
