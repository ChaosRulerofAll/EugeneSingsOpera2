using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Judging : MonoBehaviour
{
    //bool[] judgyAudience = new bool[149];
    [SerializeField] Chair[] seats;

    private void Start()
    {
        GameManager.Instance.judging = this;
        seats = this.GetComponentsInChildren<Chair>();
    }

    float CompareValues(float targetValue, float currentValue)
    {
        return math.abs(targetValue - currentValue) + 0.0001f;
    }

    public void CalculateAudienceAcceptance(float targetValue, float currentValue)
    {
        ResetValues();

        float cValue = CompareValues(targetValue, currentValue);

        float percentage = Mathf.Ceil((1 - cValue) * seats.Length);
        print(percentage);

        for (int i = 0; i < percentage; i++)
        {
            seats[i].CheckIsHappy(true);
        }
    } 

    void ResetValues()
    {
        for (int i = 0; i < seats.Length; i++)
        {
            seats[i].CheckIsHappy(false);
        }
    }

    void Update()
    {
        CalculateAudienceAcceptance(GameManager.Instance.target, GameManager.Instance.volume);
        //CalculateAudienceAcceptance(1, 0.25f);
    }
}
