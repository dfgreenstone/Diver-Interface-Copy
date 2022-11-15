using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactInfoManager : MonoBehaviour
{
    // get contact info from other manager: Information Manager, perhaps also the Call manager?
    public GameObject informationManager;

    // to get main screen animator
    public GameObject pageScreen;

    // contact page objects
    [Header("Contact Page")]
    public GameObject contactNameText;
    public GameObject contactFrequencyText;
    public GameObject contactLocationText;

    // contact info list
    //public GameObject contact1Button;

    // route list


    // Start is called before the first frame update
    void Start()
    {
        // set constants, ex. contact list, route list
    }

    // Update is called once per frame
    void Update()
    {
        // use information from the animator to format the contact info page
        MainScreenAnimator MSA = pageScreen.GetComponent<MainScreenAnimator>();
        /*if (MSA.contactSelected != -1)
        {
            // should set up contact page based on contactSelected as an index
        }*/
        //for efficiency maybe, just check if the contactSelected has changed
    }
}
