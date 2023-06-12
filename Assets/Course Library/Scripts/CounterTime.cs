using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterTime : MonoBehaviour
{
    private float initialTime;
    private float lastTime;
    private bool timeIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        initialTime = 3.0f;
        timeIsRunning = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning)
        {
            if(lastTime < 30.0f)
            {
                lastTime -= Time.deltaTime;

            }
            else
            {
                lastTime = 0;
                timeIsRunning = false;
            }
        }
    }

    public string DisplayTime()
    {
        if (timeIsRunning)
        {
            lastTime += 1;
            float seconds = Mathf.FloorToInt(lastTime / 60);
            if(seconds == 0.0f || seconds <= 9.0f)
            {
                Debug.Log("Test 3");
                return "3";
            }
            else if(seconds >= 10.0f || seconds <= 19.0f)
            {
                Debug.Log("Test 2");
                return "2";
            }
            else if(seconds >= 20.0 || seconds <= 29.0f)
            {
                Debug.Log("Test 1");
                return "1";
            }
            else
            {
                Debug.Log("GO!");
                return "GO!";
            }
            //return string.Format("{0:0}", seconds);
        }
        return "GO!";
    }

    public float TimeIsZero()
    {
        return lastTime;
    }

    public void ResetTime()
    {
        lastTime = initialTime;
    }

    public bool TimeIsRunnig()
    {
        return timeIsRunning;
    }

    public void StopTime()
    {
        timeIsRunning = false;
    }


    public void StartTime()
    {
        timeIsRunning = true;
    }
}
