using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrabberScript : OVRGrabber    //Custom script/class derives from OVRGrabber
{

    protected override void GrabBegin()         //Gets called instead of actual GrabBegin()
    {
        List<OVRGrabbable> ToRemove = new List<OVRGrabbable>();     //creates empty list for items

        foreach (OVRGrabbable grabbable in m_grabCandidates.Keys)   //loops through each item
        {
            if (grabbable == null)   //If has been deleted but not removed from list (null reference)
            {
                ToRemove.Add(grabbable);    //Adds object to the list of keys that need to be removed
            }
        }

        for (int i = 0; i < ToRemove.Count; i++)    //Loops through items that need to be removed
        {
            m_grabCandidates.Remove(ToRemove[i]);   //Removes them from dictionary
        }

        base.GrabBegin();     //Calls original function
    }
}
