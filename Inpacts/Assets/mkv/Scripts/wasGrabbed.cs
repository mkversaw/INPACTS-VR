using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasGrabbed : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized] public bool grabbed = false;
    [System.NonSerialized] public bool highlighted = false;

    // Update is called once per frame
    void Update()
    {
        
        if (!grabbed && GetComponent<highlight2>().isHighlighted && GetComponent<OVRGrabbable>().isGrabbed) // only count as grabbed if highlighted
        {
            grabbed = true;
            GetComponent<highlight2>().unhighlightObj(); // remove highlight object
            highlighted = false;
        }
       
    }
}
