using UnityEngine;

public class Mic : MonoBehaviour
{
    string deviceName = null;
    [SerializeField] int sampleRate = 44100;     
    [SerializeField] int sample = 1024;
    
    [Range(0f, 1f)]
    public float loudness01; 
    float raw;       
    
    float sensitivity = 2.0f;
    float smoothing = 10.0f;

    AudioClip _micClip;
    float[] _buffer;
    bool _micReady;

    void Start()
    {
        GameManager.Instance.mic = this;
        
        _buffer = new float[sample];

        if (Microphone.devices == null || Microphone.devices.Length == 0)
        {
            enabled = false;
            return;
        }
        
        if (string.IsNullOrEmpty(deviceName))
            deviceName = Microphone.devices[0];

        _micClip = Microphone.Start(deviceName, loop: true, lengthSec: 1, frequency: sampleRate);

        while (Microphone.GetPosition(deviceName) <= 0) { }

        _micReady = true;
    }

    void Update()
    {
        if (!_micReady || _micClip == null) return;

        int micPos = Microphone.GetPosition(deviceName);
        if (micPos < sample) return;

        int startPos = micPos - sample;
        
        _micClip.GetData(_buffer, startPos);
        
        double sumSquares = 0.0;
        for (int i = 0; i < sample; i++)
        {
            float s = _buffer[i];
            sumSquares += s * s;
        }

        raw = Mathf.Sqrt((float)(sumSquares / sample));
        
        float target01 = Mathf.Clamp01(raw * sensitivity);

        float t = 1f - Mathf.Exp(-smoothing * Time.deltaTime);
        loudness01 = Mathf.Lerp(loudness01, target01, t);
    }
}
