using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class MapTileController : MonoBehaviour
{
    public Button InfoTile;

    [SerializeField] private TypeMap _typeMap;

    [SerializeField] private MapTile _mapTile;
    public MapTile MapTile 
    { 
        get => _mapTile;
        set
        {
            _mapTile = value;
            ShowTile();
        }
    }

    [Header("Enemies")]
    [SerializeField] private int _needKill;

    public int NeedKill { get =>  _needKill; private set => _needKill = value; }

    [SerializeField] private List<Enemy> _enemies;
    public List<Enemy> Enemies { get => _enemies; private set => _enemies = value; }

    [Header ("Info")]
    [SerializeField] private Image _closeIcon;
    [SerializeField] private TextMeshProUGUI _kill;

    [Header("Image")]
    [SerializeField] private Sprite _fightBackground;
    public Sprite FightBackground { get => _fightBackground; private set => _fightBackground = value; }

    private void Awake()
    {
        InfoTile = GetComponent<Button>();
    }

    private void ShowTile()
    {
        switch (MapTile.TypeTile)
        {
            case TypeMapTile.Unavailable:
                _closeIcon.gameObject.SetActive(false);
                _kill.gameObject.SetActive(false);
                break;
            case TypeMapTile.Close:
                _closeIcon.gameObject.SetActive(true);
                _kill.gameObject.SetActive(false);
                break;
            case TypeMapTile.Open:
                _closeIcon.gameObject.SetActive(false);

                _kill.gameObject.SetActive(true);
                _kill.text = MapTile.KillCount + " / " + NeedKill;
                break;
        }
    }
}