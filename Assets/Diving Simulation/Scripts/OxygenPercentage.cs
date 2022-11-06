using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPercentage : MonoBehaviour
{

    public InformationManager iM;
    public TextMesh tM;
    private Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        tM.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        float oxyPercent = iM.GetOxygenLevel();
        tM.text = "Oxygen level: " + oxyPercent;
        float rVal = 1f - (oxyPercent / 100f);
        float gVal = oxyPercent / 100f;
        float bVal = 0.5f * (oxyPercent / 100f);
        newColor = new Color(rVal, gVal, bVal, 1f);
        tM.color = newColor;
    }
}
