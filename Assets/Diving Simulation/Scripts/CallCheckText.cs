using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCheckText : MonoBehaviour
{

    private bool isBusy, isIncomingCall;
    public GameObject simpleDialer;
    public OVRHand leftHand;
    SimpleDial playerTransmitter;
    public TextMesh tM;

    private void Awake()
    {
        if (leftHand == null) leftHand = GetComponent<OVRHand>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransmitter = simpleDialer.GetComponent<SimpleDial>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isBusy = playerTransmitter.CheckBusy();
        isIncomingCall = playerTransmitter.CheckIncoming();
        if (isIncomingCall)
        {
            tM.color = Color.yellow;
            tM.text = "Incoming call from " + playerTransmitter.CheckInFreq();
            tM.GetComponent<MeshRenderer>().enabled = true;

            bool isIndexFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
            OVRHand.TrackingConfidence confidence = leftHand.GetFingerConfidence(OVRHand.HandFinger.Index);

            if ((confidence == OVRHand.TrackingConfidence.High) && isIndexFingerPinching)
            {
                playerTransmitter.AnswerCall();
            }
        }
        else if (isBusy)
        {
            tM.color = Color.red;
            tM.text = "In a call.";
            tM.GetComponent<MeshRenderer>().enabled = true;
        }

        else {
            tM.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
