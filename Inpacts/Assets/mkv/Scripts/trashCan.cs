using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{

    public GameObject leftHandRef;
    public GameObject rightHandRef;

    [System.NonSerialized] public bool hasGloves = true;
    [System.NonSerialized] public bool deletedStrip = false;
    [System.NonSerialized] public bool deletedCap = false;

    private Texture handTex;


    public GameObject testStripRef;
    public GameObject lancetCapRef;

    void Start()
    {
        Texture handTex = leftHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture; // get the meshRenderer component from the hand(s)
    }

    private void OnCollisionEnter(Collision other)
    {
        if (this.GetComponent<highlight2>().isHighlighted) // only delete if highlighted
        {
            if (other.gameObject == leftHandRef || other.gameObject == rightHandRef) // GLOVES CASE
            {
                if(hasGloves) // remove gloves
                {
                    leftHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;
                    rightHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;
                    hasGloves = false;
                    TryMoveOn();

                }
            } else if (other.gameObject == testStripRef)
            {
                testStripRef.SetActive(false);
                deletedStrip = true;
                TryMoveOn();
            } else if (other.gameObject == lancetCapRef)
            {
                lancetCapRef.SetActive(false);
                deletedCap = true;
                TryMoveOn();
            }
        }
    }

    private void TryMoveOn()
    {
        if (!hasGloves && deletedStrip && deletedCap)
        {
            this.GetComponent<highlight2>().unhighlightObj(); // remove highlight
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager!
        }
    }
}
