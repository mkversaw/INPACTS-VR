using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHand : MonoBehaviour
{
    public GameObject ovrgrabberRef;
    public Renderer normalRend; // Default hand
    public Renderer fistRend; // Fist hand
    public bool buttonMode = true;
    public bool right = true; // which hand

    private bool canSwitch = true;

    void Start()
    {
        normalRend.enabled = true;
        fistRend.enabled = false;
    }

    private bool checkButtonDown()
    {
        if(!right)
        {
            return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        } else
        {
            return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
        }
    }

    private bool checkButtonUp()
    {
        if (!right)
        {
            return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger);
        }
        else
        {
            return OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);
        }
    }

    private bool checkButton()
    {
        if (!right)
        {
            return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        }
        else
        {
            return OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
        }
    }
    private void Update()
    {
        if (canSwitch)
        {
            if (ovrgrabberRef.GetComponent<OVRGrabber>().grabbedObject != null || (buttonMode && checkButton())) // object is held!
            {
                fist();
            }
            else
            {
                normal();
            }
        }
    }

    public void normal()
    {
        canSwitch = true;
        normalRend.enabled = true;

        //pinchRend.enabled = false;
        fistRend.enabled = false;
    }
    public void fist()
    {
        fistRend.enabled = true;

        normalRend.enabled = false;
        //pinchRend.enabled = false;
    }

    public void pinch()
    {
        //pinchRend.enabled = true;

        fistRend.enabled = false;
        normalRend.enabled = false;
        
    }

    public void none()
    {
        //pinchRend.enabled = false;
        canSwitch = false;
        fistRend.enabled = false;
        normalRend.enabled = false;
    }

}
