using UnityEngine;

public class Chair : MonoBehaviour
{

    [SerializeField] GameObject sadMask;
    [SerializeField] GameObject happyMask;
    [SerializeField] Transform face;

    Vector3 happyPos;
    Vector3 sadPos;

    bool isHappy = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        happyPos = happyMask.transform.localPosition;
        sadPos = sadMask.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHappy)
        {
            MakeHappy();
        }
        else
        {
            MakeSad();
        }
    }

    void MakeHappy()
    {
        sadMask.gameObject.transform.localPosition = sadPos;
        happyMask.gameObject.transform.localPosition = face.transform.localPosition;
    }
    
    void MakeSad()
    {
        happyMask.gameObject.transform.localPosition = happyPos;
        sadMask.gameObject.transform.localPosition = face.transform.localPosition;
    }

    public void CheckIsHappy(bool happy)
    {
        isHappy = happy;
    }
}
