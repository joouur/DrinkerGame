using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
