using UnityEngine;
using UnityEngine.UI;

public class UnloadSceneButton : MonoBehaviour
{
    [SerializeField] private float _timeScale;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(UnloadScene);
    }

    private void UnloadScene()
    {
        ScenesManager.UnloadScene(_timeScale);
    }
}