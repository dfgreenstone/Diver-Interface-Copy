using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallManager : MonoBehaviour
{
    public Text dialBox;
    public bool callAllowed = false;

    public void PressNumber(int number)
    {
        if (dialBox.text.Length < 4)
        {
            dialBox.text += number.ToString();
        }
    }

    public void PressDelete()
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
        
    }

    public void PressClear()
    {
        dialBox.text = "";
    }

    void Update()
    {
        if (dialBox.text.Length == 4)
        {
            callAllowed = true;
            //need to check if frequency is in range, and if not, give an error message
        }
        else 
        {
            callAllowed = false;
        }
    }
}
