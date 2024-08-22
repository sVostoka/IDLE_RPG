using UnityEngine.SceneManagement;
using static Enums;

public static class ScenesManager
{
    public static void LoadScene(Scenes scene, float timeScale = 1, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        var sceneId = (int)scene;
        SceneManager.LoadScene(sceneId, loadSceneMode);

        SceneManager.sceneLoaded += OnSceneLoaded;

        ResourceManager.s_Instance.TimeScale = timeScale;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }

    public static void UnloadScene(float timeScale = 1)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        ResourceManager.s_Instance.TimeScale = timeScale;
    }
}
