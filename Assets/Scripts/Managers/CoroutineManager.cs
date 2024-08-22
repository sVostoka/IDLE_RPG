using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager s_Instance { get; private set; } = null;

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
    }
}
