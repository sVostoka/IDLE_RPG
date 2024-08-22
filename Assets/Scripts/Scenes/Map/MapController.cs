using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private int _rowsCount;
    [SerializeField] private int _columnsCount;

    [SerializeField] private InfoTileController _infoTile;

    public delegate void UpdateMap(MapTileController[,] mapTiles, MapTile[,] mapData, Vector2 startPosition);
    public event UpdateMap Update;
    
    public MapTile[,] MapData { get; private set; }
    public MapTileController[,] MapTiles { get; private set; }

    private void Awake()
    {
        MapData = new MapTile[_rowsCount, _columnsCount];
        MapTiles = new MapTileController[_rowsCount, _columnsCount];
    }

    private void Start()
    {
        SaveMap();
        SetMap();
    }

    private void SaveMap()
    {
        MapTileController[] map = GetComponentsInChildren<MapTileController>();

        for (int i = 0; i < map.Length; i++)
        {
            int row = i / _columnsCount;
            int column = i % _columnsCount;

            MapTiles[row, column] = map[i];
            MapData[row, column] = map[i].MapTile;
        }

        Update?.Invoke(MapTiles, MapData, _startPosition);
    }

    private void SetMap()
    {
        MapData = ResourceManager.s_Instance.MapData.MapTiles;

        for(int i = 0; i< _rowsCount; i++)
        {
            for(int j = 0; j < _columnsCount; j++)
            {
                int row = i;
                int column = j;

                MapTiles[row, column].MapTile = MapData[row, column];

                MapTiles[row, column].InfoTile.onClick.AddListener( delegate { ShowInfo(row, column); });
            }
        }
    }

    private void ShowInfo(int x, int y)
    {
        _infoTile.Show(MapTiles[x, y], new(x, y));
    }
}
