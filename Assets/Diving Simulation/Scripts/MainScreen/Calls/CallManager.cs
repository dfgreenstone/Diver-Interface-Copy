using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallManager : MonoBehaviour
{
    public Text dialBox;
    public bool callAllowed = false;

    public OVRHand leftHand;

    public GameObject ctm;
    public GameObject simpledialer;
    public GameObject planeScreen;

    private bool pressedNumber = false;
    private bool pressedDelete = false;
    private bool pressedClear = false;

    public Text callPageText;

    private void Awake()
    {
        if (leftHand == null) leftHand = GetComponent<OVRHand>();
    }

    public void PressNumber(int number)
    {
        if (!pressedNumber)
        {
            pressedNumber = true;
            StartCoroutine(addNumber(number));
        }

        //if (dialBox.text.Length < 4)
        //{
        //    dialBox.text += number.ToString();
        //}
    }

    private IEnumerator addNumber(int number)
    {
        if (dialBox.text.Length < 4)
        {
            dialBox.text += number.ToString();
        }
        yield return new WaitForSeconds(1f);
        pressedNumber = false;
    }

    public void PressDelete()
    {
        if (!pressedDelete)
        {
            pressedDelete = true;
            StartCoroutine(removeNumber());
        }
        //int length = dialBox.text.Length;
        //if (length > 0)
        //{
        //    if (length > 1)
        //    {
        //        dialBox.text = dialBox.text.Substring(0, length - 2);
        //    }
        //    else if (length == 1)
        //    {
        //        dialBox.text = "";
        //    } 
        //}
    }

    private IEnumerator removeNumber()
    { 
        int length = dialBox.text.Length;
        if (length > 0)
        {
            if (length > 1)
            {
                dialBox.text = dialBox.text.Substring(0, length - 2);
            }
            else if (length == 1)
            {
                dialBox.text = "";
            }

        }
        yield return new WaitForSeconds(1f);
        pressedDelete = false;
    }

    public void PressClear()
    {
        if (!pressedClear)
        {
            pressedClear = true;
            StartCoroutine(clearNumber());
        }
        //dialBox.text = "";
    }

    private IEnumerator clearNumber()
    {
        dialBox.text = "";
        yield return new WaitForSeconds(1f);
        pressedClear = false;
    }

    void FixedUpdate()
    {
        if (dialBox.text.Length == 4)
        {
            bool isIndexFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
            OVRHand.TrackingConfidence confidence = leftHand.GetFingerConfidence(OVRHand.HandFinger.Index);

            if ((confidence == OVRHand.TrackingConfidence.High) && isIndexFingerPinching)
            {
                callAllowed = true;
                int callFrequency = int.Parse(dialBox.text);

                CallTowerManager callTowerManager = ctm.GetComponent<CallTowerManager>();
                SimpleDial sm = simpledialer.GetComponent<SimpleDial>();

                int[] allowedFrequencies = callTowerManager.crewmateFrequencies;
                CrewInfo[] crewInfo = callTowerManager.GetCrewmatesInformation();

                callPageText.text = "";

                for (int i = 0; i < allowedFrequencies.Length; i++)
                {
                    if (callFrequency == allowedFrequencies[i])
                    {
                        callPageText.text = "Calling " + crewInfo[i].name;
                    }
                }

                if (callPageText.text.Length == 0)
                {
                    if (callFrequency == callTowerManager.GetEmergencyFrequency())
                    {
                        callPageText.text = "Calling Emergency";
                    }
                    else
                    {
                        callPageText.text = "Calling Unknown";
                    }
                }

                sm.QuickDial(callFrequency);
                MainScreenAnimator msa = planeScreen.GetComponent<MainScreenAnimator>();
                msa.ToCallingPage(callFrequency);
            }   
        }
        else 
        {
            callAllowed = false;
        }
    }
}
