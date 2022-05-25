using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{

    public GameObject snapLocation;
    public GameObject snapParent;
    public bool isSnapped;
    private bool wasEverSnapped = true;
    private bool first = true;
    public bool immovableOnceSnapped;
    private bool objectSnapped;
    private bool grabbed;

    // Update is called once per frame
    void Update()
    {
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;
        objectSnapped = snapLocation.GetComponent<snapToLocation>().isSnapped;

        // once snapped, set rigidbody to be kinematic
        // make snapped object a child of the obj its snapped to
        if(objectSnapped)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(snapParent.transform);
            isSnapped = true;
            wasEverSnapped = true;
        }

        if(wasEverSnapped && !objectSnapped && first)
        {
            print("bazinga");
            transform.parent = null;
            //GetComponent<Rigidbody>().isKinematic = false;
        }

        // ensure that object is still able to be grabbed by OVRGrabber script
        if (!immovableOnceSnapped)
        {
            if (!objectSnapped && !grabbed)
            {
                print("TEST!!!!!!!!!!");
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
