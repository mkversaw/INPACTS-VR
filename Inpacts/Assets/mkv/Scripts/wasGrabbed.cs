using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasGrabbed : MonoBehaviour
{
    [System.NonSerialized] public bool grabbed = false;
    [System.NonSerialized] public bool highlighted = false;

    public bool shouldMoveOn = false;

    void Update()
    {
        
        if (!grabbed && GetComponent<highlight2>().isHighlighted && GetComponent<OVRGrabbable>().isGrabbed) // only count as grabbed if highlighted
        {
            grabbed = true;
            GetComponent<highlight2>().unhighlightObj(); // remove highlight object
            highlighted = false;

            if(shouldMoveOn)
            {
                GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager
            }
        }
       
    }
}
