using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallManager : MonoBehaviour
{
    public Text dialBox;
    public bool callAllowed = false;

    private bool pressedNumber = false;
    private bool pressedDelete = false;
    private bool pressedClear = false;

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
