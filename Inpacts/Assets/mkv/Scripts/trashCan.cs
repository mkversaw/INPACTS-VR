using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{

    public GameObject leftHandRef;
    public GameObject handLeftFist;
    public GameObject rightHandRef;
    public GameObject handRightFist;
    public GameObject leftCollider;
    public GameObject rightCollider;

    [System.NonSerialized] public bool hasGloves = true;
    [System.NonSerialized] public bool deletedStrip = false;
    [System.NonSerialized] public bool deletedUrineStrip = false;
    [System.NonSerialized] public bool deletedUrineCup = false;
    [System.NonSerialized] public bool deletedCap = true;

    private Texture handTex;


    public GameObject testStripRef;
    public GameObject lancetCapRef;
    public GameObject urineStripRef;
    public GameObject urineCupRef;

    private GameObject manager;

    private bool wasHighlighted = false;
    private bool round2 = false;

    void Start()
    {
        Texture handTex = leftHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture; // get the meshRenderer component from the hand(s)
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void round2Checks()
    {
        wasHighlighted = false;
        hasGloves = false;
        round2 = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.GetComponent<highlight2>().isHighlighted || wasHighlighted) // only delete if highlighted
        {
            if (other.gameObject == leftCollider || other.gameObject == rightCollider) // GLOVES CASE
            {
                wasHighlighted = true;
                gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight

                if (hasGloves) // remove gloves
                {
                    leftHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;
                    rightHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;
                    handLeftFist.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;
                    handRightFist.GetComponent<SkinnedMeshRenderer>().material.mainTexture = handTex;

                    manager.GetComponent<createSmoke>().spawnSmoke(other.transform);

                    hasGloves = false;
                    TryMoveOn();

                }
            } else if (other.gameObject == testStripRef)
            {
                wasHighlighted = true;
                gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight

                testStripRef.SetActive(false);
                deletedStrip = true;
                manager.GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
                TryMoveOn();
            } else if (other.gameObject == lancetCapRef)
            {
                wasHighlighted = true;
                gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight

                lancetCapRef.SetActive(false);
                deletedCap = true;
                manager.GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
                TryMoveOn();
            } else if (other.gameObject == urineStripRef)
            {
                wasHighlighted = true;
                gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight

                urineStripRef.SetActive(false);
                deletedUrineStrip = true;
                manager.GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
                TryMoveOn();
            } else if (other.gameObject == urineCupRef)
            {
                wasHighlighted = true;
                gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight

                urineCupRef.SetActive(false);
                deletedUrineCup = true;
                manager.GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
                TryMoveOn();
            }
        }
    }

    private void TryMoveOn()
    {
        if(round2 && !hasGloves && deletedUrineCup && deletedUrineStrip)
        {
            this.GetComponent<highlight2>().unhighlightObj(); // remove highlight
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager!
        }
        else if (!hasGloves && deletedStrip && deletedCap)
        {
            this.GetComponent<highlight2>().unhighlightObj(); // remove highlight
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager!
        }
    }
}
