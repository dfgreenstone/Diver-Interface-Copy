using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupeOxy : MonoBehaviour
{

    public InformationManager iM;
    public TextMesh tM;

    // Start is called before the first frame update
    void Start()
    {
        tM.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        float oxyPercent = iM.GetOxygenLevel();
        tM.text = "Oxygen level: " + oxyPercent;
    }
}
