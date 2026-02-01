using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public Mic mic;
    public Judging judging;
    public ConductorManager conductorManager;

    public float target;
    public float volume;
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

    public void HitThatNoteKevin()
    {
        
    }
}
