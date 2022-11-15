using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPhone : MonoBehaviour
{

    public GameObject phone;
    private bool phoneEnabled = false;

    public OVRHand leftHand;

    public bool leftThumbDown = false;
    public bool leftThumbUp = false;

    public void thumbsDownLeft(bool s)
    {
        leftThumbDown = s;
    }

    public void thumbsUpLeft(bool s)
    {
        leftThumbUp = s;
    }

    private void Awake()
    {
        if (leftHand == null) leftHand = GetComponent<OVRHand>();
    }

    // Start is called before the first frame update
    void Start()
    {
        phone.SetActive(false);
    }

    private void FixedUpdate()
    {
        ThumbMovement();
    }

    void ThumbMovement()
    {
        if (leftThumbDown && phoneEnabled)
        {
            phoneEnabled = false;
        }
        else if (leftThumbUp && !phoneEnabled)
        {
            phoneEnabled = true;
        }
        else
        {
            phoneEnabled = phoneEnabled;
        }

        if (phone.activeInHierarchy != phoneEnabled)
        {
            phone.SetActive(phoneEnabled);
        }
    }
}
