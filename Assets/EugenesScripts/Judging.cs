using Unity.Mathematics;
using UnityEngine;

public class Judging : MonoBehaviour
{
    int seats = 0;
    bool[] judgyAudience = new bool[seats];

    float CompareValues(float targetValue, float currentValue)
    {
        return math.abs(targetValue - currentValue) + 0.0001f;
    }

    public void CalculateAudienceAcceptance()
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
        for (int i = 0; i < judgyAudience.Length; i++)
        {
            judgyAudience[i] = false;
        }
    }
}
