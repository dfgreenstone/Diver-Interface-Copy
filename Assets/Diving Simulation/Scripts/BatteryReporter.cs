using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryReporter : MonoBehaviour
{

    public InformationManager iM;
    TextMesh battText;

    // Start is called before the first frame update
    void Start()
    {
        battText = this.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        float batteryLevel = iM.GetBatteryLevel();
        battText.text = "Battery level:\n" + batteryLevel;
    }
}
