using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthAndTime : MonoBehaviour
{

    public InformationManager iM;
    private int seconds, minutes;
    private string timeString;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0;
        StartCoroutine(TimerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        float depth = iM.GetDepth();
        float battery = iM.GetBatteryLevel();
        minutes = (int) Math.Floor(seconds / 60f);
        timeString = minutes + ":" + (seconds - (minutes * 60));
    }



    IEnumerator TimerCoroutine() 
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            seconds++;
        }
    }
}
