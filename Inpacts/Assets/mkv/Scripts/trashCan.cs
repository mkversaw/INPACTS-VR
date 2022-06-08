using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{

    public GameObject leftHandRef;
    public GameObject rightHandRef;
    public GameObject leftCollider;
    public GameObject rightCollider;

    [System.NonSerialized] public bool hasGloves = true;
    [System.NonSerialized] public bool deletedStrip = false;
    [System.NonSerialized] public bool deletedCap = false;

    private Texture handTex;


    public GameObject testStripRef;
    public GameObject lancetCapRef;
    private GameObject manager;

    bool wasHighlighted = false;

    void Start()
    {
        Texture handTex = leftHandRef.GetComponent<SkinnedMeshRenderer>().material.mainTexture; // get the meshRenderer component from the hand(s)
        manager = GameObject.FindGameObjectWithTag("Manager");
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
