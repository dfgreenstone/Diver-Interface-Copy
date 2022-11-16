using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactInfoManager : MonoBehaviour
{
    // get contact info from other manager: Information Manager, perhaps also the Call manager?
    //public GameObject informationManager;

    public GameObject callTowerManager;

    // to get main screen animator
    //public GameObject pageScreen;

    public Text contactNumber;

    // contact page objects
    [Header("Contact Page")]
    public Text contactName;
    public Text contactFrequency;
    public Text contactLocation;

    public Text routeContactName;
    public Text routeContactLocation;

    //public GameObject contactNameText;
    //public GameObject contactFrequencyText;
    //public GameObject contactLocationText;

    // contact info list
    //public GameObject contact1Button;

    // route list


    // Start is called before the first frame update
    void Start()
    {
        contactName.text = "";
        contactFrequency.text = "Freq #: ";
        contactLocation.text = "Location: ";

        routeContactName.text = "Set Route to ";
        routeContactLocation.text = "Location :";
        // set constants, ex. contact list, route list
    }

    // Update is called once per frame
    void Update()
    {
        CallTowerManager ctm = callTowerManager.GetComponent<CallTowerManager>();
        int[] allowedFrequencies = ctm.crewmateFrequencies;
        CrewInfo[] crewInfo = ctm.GetCrewmatesInformation();

        int index = int.Parse(contactNumber.text);

        int cur_crew_frequency = allowedFrequencies[index];
        string cur_crew_name = crewInfo[index].name;
        Vector3 cur_crew_pos = crewInfo[index].worldLocation;

        contactName.text = cur_crew_name;
        contactFrequency.text = "Freq #: " + cur_crew_frequency.ToString();
        contactLocation.text = "Location:\nx - " + cur_crew_pos.x.ToString("#.##") + "\ny - " + cur_crew_pos.y.ToString("#.##") + "\nz - " + cur_crew_pos.z.ToString("#.##");

        routeContactName.text = "Set Route to " + cur_crew_name;
        routeContactLocation.text = "Location:\nx - " + cur_crew_pos.x.ToString("#.##") + "\ny - " + cur_crew_pos.y.ToString("#.##") + "\nz - " + cur_crew_pos.z.ToString("#.##");

        // use information from the animator to format the contact info page
        //MainScreenAnimator MSA = pageScreen.GetComponent<MainScreenAnimator>();
        /*if (MSA.contactSelected != -1)
        {
            // should set up contact page based on contactSelected as an index
        }*/
        //for efficiency maybe, just check if the contactSelected has changed
    }
}
