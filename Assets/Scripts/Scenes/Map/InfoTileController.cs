using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoTileController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _typeTile;
    [SerializeField] private TextMeshProUGUI _killCount;
    [SerializeField] private Button _changePosition;

    private Vector2 _position;

    private void Awake()
    {
        _changePosition.onClick.AddListener(ChangePosition);
        Hide();
    }

    public void Show(MapTileController mapTile, Vector2 position)
    {
        _position = position;

        _killCount.text = mapTile.MapTile.KillCount + " / " + mapTile.NeedKill;

        switch (mapTile.MapTile.TypeTile)
        {
            case Enums.TypeMapTile.Open:
                _typeTile.text = "Открытая";
                _typeTile.gameObject.SetActive(true);
                _killCount.gameObject.SetActive(true);

                _changePosition.gameObject.SetActive(true);
                break;
            case Enums.TypeMapTile.Close:
                _typeTile.text = "Закрытая";
                _typeTile.gameObject.SetActive(true);
                _killCount.gameObject.SetActive(true);

                _changePosition.gameObject.SetActive(false);
                break;
            case Enums.TypeMapTile.Unavailable:
                _typeTile.text = "Недоступная";
                _typeTile.gameObject.SetActive(true);
                _killCount.gameObject.SetActive(false);

                _changePosition.gameObject.SetActive(false);
                break;
        }
    }

    private void Hide()
    {
        _typeTile.gameObject.SetActive(false);
        _killCount.gameObject.SetActive(false);

        _changePosition.gameObject.SetActive(false);
    }

    private void ChangePosition()
    {
        ResourceManager.s_Instance.MapData.Position = _position;
        ScenesManager.UnloadScene();
    }
}
