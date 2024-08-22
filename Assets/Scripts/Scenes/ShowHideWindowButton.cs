using UnityEngine;

public class ShowHideWindowButton : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    public void ShowWindow()
    {
        _window.SetActive(true);
        ResourceManager.s_Instance.TimeScale = 0;
    }

    public void HideWindow()
    {
        _window.SetActive(false);
        ResourceManager.s_Instance.TimeScale = 1;
    }
}

