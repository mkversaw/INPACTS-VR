using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapToLocation : MonoBehaviour
{

    private bool grabbed; // if object is currently held
    private bool insideSnapZone; // if object is touching snap collider
    public bool isSnapped;
    public bool instantSnap;

    public GameObject snapReference; // what (and where) to snap to
    public GameObject rotationReference; // what rotation the object should have once rotated

    // Detect if object enters the snap zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == snapReference.name)
        {
            print(other.gameObject.name + " is inside snap zone!");
            insideSnapZone = true;
        }
    }

    // Detect if object leaves the snap zone
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == snapReference.name)
        {
            print(other.gameObject.name + " left the snap zone!");
            insideSnapZone = false;
        }
    }

    void snapObj()
    {
        if(instantSnap && insideSnapZone)
        {
            snapReference.gameObject.transform.position = this.transform.position;
            snapReference.gameObject.transform.rotation = rotationReference.transform.rotation;
            isSnapped = true;
        } 
        else if(!grabbed && insideSnapZone)
        {
            snapReference.gameObject.transform.position = this.transform.position;
            snapReference.gameObject.transform.rotation = rotationReference.transform.rotation;
            isSnapped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        grabbed = snapReference.GetComponent<OVRGrabbable>().isGrabbed;
        snapObj();
    }
}
