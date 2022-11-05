using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAlert : MonoBehaviour
{

    public InformationManager iM;
    public AudioSource alertSound;
    public GameObject centerWarning;
    public GameObject sideWarning;
    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {  
        alertSound.playOnAwake = false;
        hasPlayed = false;
        sideWarning.SetActive(false);
        centerWarning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float currBattPercent = iM.GetBatteryLevel();
        if(currBattPercent <= 15f && !(alertSound.isPlaying) && !(hasPlayed))
        {
            alertSound.Play();
            Debug.Log("Alert sound playing.");
            hasPlayed = true;
            sideWarning.SetActive(true);
            StartCoroutine(CWarnFlash());
        }
    }

    IEnumerator CWarnFlash()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 3; j++) {
                centerWarning.SetActive(true);
                yield return new WaitForSeconds(1f);
                centerWarning.SetActive(false);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
