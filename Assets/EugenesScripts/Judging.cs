using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Judging : MonoBehaviour
{
    bool[] judgyAudience = new bool[30];

    private void Start()
    {
        GameManager.Instance.judging = this;
    }

    float CompareValues(float targetValue, float currentValue)
    {
        return math.abs(targetValue - currentValue) + 0.0001f;
    }

    public void CalculateAudienceAcceptance(float targetValue, float currentValue)
    {
        ResetValues();

        float cValue = CompareValues(targetValue, currentValue);

        float percentage = Mathf.Ceil((1 - cValue) * 30);
        print(percentage);

        for (int i = 0; i < percentage; i++)
        {
            judgyAudience[i] = true;
        }
    } 

    void ResetValues()
    {
        for (int i = 0; i < judgyAudience.Length; i++)
        {
            judgyAudience[i] = false;
        }
    }

    void Update()
    {
        CalculateAudienceAcceptance(GameManager.Instance.target, GameManager.Instance.volume);
        //CalculateAudienceAcceptance(1, 0.25f);
    }
}
