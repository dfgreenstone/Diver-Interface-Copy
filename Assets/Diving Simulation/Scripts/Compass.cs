using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject arrow;

    public Text contactNumber;
    public GameObject callTowerManager;

    public Transform player;

    public OVRHand rightHand;
    public bool rightFist = false;

    private Vector3 northDirection = Vector3.zero;
    private Quaternion targetDirection;

    public Text distanceText;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        distanceText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
    }

    void UpdateTargetDirection()
    {
        CallTowerManager ctm = callTowerManager.GetComponent<CallTowerManager>();

        CrewInfo[] crewInfo = ctm.GetCrewmatesInformation();

        Vector3 target = crewInfo[int.Parse(contactNumber.text)].worldLocation;

        Vector3 direction = target - player.position;

        targetDirection = Quaternion.LookRotation(direction);

        targetDirection.x = -targetDirection.x;

        arrow.transform.rotation = targetDirection * Quaternion.Euler(0, 90, 0);

        distanceText.text = " Distance to " + crewInfo[int.Parse(contactNumber.text)].name + ": " + direction.magnitude.ToString("#.##") + ".";

        if (direction.magnitude < 10)
        {
            arrow.SetActive(false);
            distanceText.text = "";
        }

        if (rightFist)
        {
            arrow.SetActive(false);
            distanceText.text = "";
        }
    }

    public void rightFistClenched(bool s)
    {
        rightFist = s;
    }
}
