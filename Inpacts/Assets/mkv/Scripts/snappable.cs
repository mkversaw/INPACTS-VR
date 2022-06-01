using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{

    public GameObject snapLocation;
    public GameObject snapParent;
    public bool isSnapped;
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
            
            if(!grabbed)
            {
                if (name == "Test strip")
                {
                    print("test");
                    snapLocation.GetComponent<snapToLocation>().instantSnap = false;
                }
            }
        }



        if(!objectSnapped)
        {
            //transform.parent = null;
            //GetComponent<Rigidbody>().isKinematic = false;
        }

        // ensure that object is still able to be grabbed by OVRGrabber script
        if (!immovableOnceSnapped)
        {
            if(grabbed)
            {
                
                
                //if(transform.parent != null)
                //{
                //    print(transform.parent);
                //    if (transform.parent.gameObject.layer != LayerMask.NameToLayer("Hands"))
                //    {
                //        GetComponent<Rigidbody>().isKinematic = false;
                //        //transform.parent = null;
                //    } else
                //    {
                //        print("?????");
                //    }
                //    
                //}


            }


            if (!objectSnapped && !grabbed)
            {
                //GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
