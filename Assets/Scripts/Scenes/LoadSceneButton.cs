using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Enums;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private Scenes _loadableScene;
    [SerializeField] private float _timeScale;
    [SerializeField] private LoadSceneMode _loadSceneMode;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        ScenesManager.LoadScene(_loadableScene, _timeScale, _loadSceneMode);
    }
}
