using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public Mic mic;
    public Judging judging;

    private float target = 0.5f;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    
}
