using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCheckText : MonoBehaviour
{

    private bool isBusy, isIncomingCall;
    private SimpleDial playerTransmitter;
    public TextMesh tM;

    // Start is called before the first frame update
    void Start()
    {
        playerTransmitter = new SimpleDial();
    }

    // Update is called once per frame
    void Update()
    {
        isBusy = playerTransmitter.CheckBusy();
        isIncomingCall = playerTransmitter.CheckIncoming();
        if(isBusy)
        {
            tM.color = Color.red;
            tM.text = "In a call.";
            tM.GetComponent<MeshRenderer>().enabled = true;
        }
        else if(isIncomingCall)
        {
            tM.color = Color.yellow;
            tM.text = "Incoming call from " + playerTransmitter.CheckInFreq();
            tM.GetComponent<MeshRenderer>().enabled = true;
        }
        else {
            tM.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
