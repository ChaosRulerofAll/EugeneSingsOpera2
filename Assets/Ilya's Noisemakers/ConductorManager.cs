using UnityEditor.UI;
using UnityEngine;

public class ConductorManager : MonoBehaviour
{

    bool hasHitNote = false;
    float currentNoteVolume = 0;

    float countDown = 0.0f;
    float shakeCooficient = 5.0f;

    [SerializeField] Transform shoulder;
    Transform trans;
    Transform form;
    Vector3 shaker;


    private void Start()
    {
        GameManager.Instance.conductorManager = this;
        trans = transform;
        form = transform;
    }

    private void FixedUpdate()
    {
        if (countDown < 0)
        {
            GetNextNote();
            countDown = 2.0f;

            //shoulder.rotation = Quaternion.Euler(100 * currentNoteVolume - 50, 90, 0);
            
        }

        shoulder.rotation = Quaternion.Lerp(shoulder.rotation, Quaternion.Euler(100 * currentNoteVolume - 50, 90, 0), 0.05f);
        
        shaker = new Vector3(Mathf.Sin(Time.realtimeSinceStartup * 2 * shakeCooficient),
            Mathf.Sin(Time.realtimeSinceStartup * 3 * shakeCooficient),
            Mathf.Sin(Time.realtimeSinceStartup * 7 * shakeCooficient));

        shoulder.localPosition = form.position + (shaker * 0.05f);

        countDown -= Time.deltaTime;
    }

    void GetNextNote()
    {
        currentNoteVolume = Random.Range(0.0f, 1.0f);
        GameManager.Instance.target = currentNoteVolume;
    }

    public void SetShakeCoeficient(float input)
    {
        shakeCooficient = input;
    }

}
