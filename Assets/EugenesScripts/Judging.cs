using Unity.Mathematics;
using UnityEngine;

public class Judging : MonoBehaviour
{
    public bool[] judgyAudience = new bool[30];
    public int seats;

    bool CompareValues(float targetValue, float currentValue)
    {
        return math.abs(targetValue - currentValue) + 0.0001f;
    }

    void CalculateAudienceAcceptance()
    {
        ResetValues();

        float cValue = CompareValues(targetValue, currentValue);

        float percentage = Mathf.Ceil((1 - cValue) * seats);

        for (int i = 0; i < percentage; i++)
        {
            judgyAudience[i] = true;
        }
    } 

    void ResetValues()
    {
        foreach in judgyAudience        
        {
            judgyAudience = false;
        }
    }
}
