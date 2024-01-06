using UnityEngine;

/// <summary>
/// Simple singleton to use with different components.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance { get => _instance; }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}