using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float maxValue = 100;
    public float interval = 20;
    public float currentValue;

    private float zeroTime;

    private void Awake()
    {
        zeroTime = Time.time + interval;
    }

    private void Update()
    {
        if (Time.time >= zeroTime)
        {
            Debug.Log("Zero");
        }
        else
        {
            float currentNormalizedTime = 1 - (zeroTime - Time.time) / interval;
            currentValue = Mathf.Lerp(maxValue, 0, currentNormalizedTime);
        }
    }
}