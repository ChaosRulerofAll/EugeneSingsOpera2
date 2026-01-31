using UnityEngine;

public class MusicParticle : MonoBehaviour
{

    [SerializeField] private Mic mic;
    [SerializeField] ParticleSystem musicParticle;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        musicParticle.gravityModifier = (mic.loudness01 - 0.5f) * -2;
        musicParticle.emissionRate = mic.loudness01 * 10;
    }
}
