using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthAndTimePro : MonoBehaviour
{

    public InformationManager iM;
    private int seconds, minutes;
    private string timeString;
    public TMP_Text tM;

    public Text distanceText;

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

        if (distanceText.text.Length == 0)
        {
            tM.text = "<sprite=\"lightning_spr\" index=0> Battery level: " + battery + "%.\n"
            + "<sprite=\"wave_spr\" index=0> Depth: " + depth + "m.\n"
            + "<sprite=\"clock_spr\" index=0> Time elapsed: " + timeString + ".\n";
        }
        else
        {
            tM.text = "<sprite=\"lightning_spr\" index=0> Battery level: " + battery + "%.\n"
            + "<sprite=\"wave_spr\" index=0> Depth: " + depth + "m.\n"
            + "<sprite=\"clock_spr\" index=0> Time elapsed: " + timeString + ".\n"
            + distanceText.text;
        }
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