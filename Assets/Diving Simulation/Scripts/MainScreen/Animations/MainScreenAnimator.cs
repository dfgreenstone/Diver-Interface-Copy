using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    private int state;
    //public int contactSelected = -1; //-1 means none selected

    public GameObject phone;
    public GameObject callTowerManager;
    public GameObject simpledialer;
    public Text contactNumber;
    public Text callPageText;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();

        contactNumber.text = "0";

        state = MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == _currentState) return;
        StartCoroutine(SwitchMenu());
        
    }

    private IEnumerator SwitchMenu()
    {
        yield return new WaitForSeconds(1f);
        _anim.CrossFade(state, 0, 0);
        _currentState = state;

        //foreach (Collider collider in phone.GetComponentsInChildren<Collider>())
        //{
        //    collider.enabled = false;
        //}

        //yield return new WaitForSeconds(1f);

        //foreach (Collider collider in phone.GetComponentsInChildren<Collider>())
        //{
        //    collider.enabled = true;
        //}
    }
    
    // Functions to update state
    public void ToMainMenu()
    {
        state = MainMenu;
    }

    public void ToCallMenu()
    {
        state = CallMenu;
    }

    public void ToInfoMenu()
    {
        state = InfoMenu;
    }

    public void ToRouteMenu()
    {
        state = RouteMenu;
    }

    public void ToContactPage(int pageNumber)
    {
        // contactSelected = pageNumber; // use this number for the ContactInfoManager, need some way to reset ? maybe? when you leave the contact page (back, make call, make route)
        contactNumber.text = pageNumber.ToString();
        state = ContactPage;
    }

    public void ToRouteSetPage(int pageNumber)
    {
        contactNumber.text = pageNumber.ToString();
        state = RouteSetPage;
    }

    public void ContactPageToRouteSetPage()
    {
        state = RouteSetPage;
    }

    public void ToCallingPage()
    {
        CallTowerManager ctm = callTowerManager.GetComponent<CallTowerManager>();
        SimpleDial sm = simpledialer.GetComponent<SimpleDial>();

        int[] allowedFrequencies = ctm.crewmateFrequencies;
        CrewInfo[] crewInfo = ctm.GetCrewmatesInformation();

        string name = crewInfo[int.Parse(contactNumber.text)].name;
        int frequency = allowedFrequencies[int.Parse(contactNumber.text)];

        callPageText.text = "Calling " + name;
        state = CallingPage;
        sm.QuickDial(frequency);
    }

    #region Cached Properties

    private int _currentState;

    private static readonly int MainMenu = Animator.StringToHash("Main Menu");
    private static readonly int CallMenu = Animator.StringToHash("Call Main Menu");
    private static readonly int InfoMenu = Animator.StringToHash("Info Main Menu");
    private static readonly int RouteMenu = Animator.StringToHash("Route Main Menu");
    private static readonly int ContactPage = Animator.StringToHash("Contact Page");
    private static readonly int RouteSetPage = Animator.StringToHash("Route Set Page");
    private static readonly int CallingPage = Animator.StringToHash("Calling Page");

    #endregion
}
