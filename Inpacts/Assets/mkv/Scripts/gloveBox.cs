using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloveBox : MonoBehaviour
{

    public GameObject handLeft;
    public GameObject handLeftFist;
    public GameObject handRight;
    public GameObject handRightFist;
    public GameObject leftCollider;
    public GameObject rightCollider;
    //public Material gloveMat;
    public Texture gloveTex;

    public logData logRef;

    [System.NonSerialized]  public bool highlighted = false;

    [System.NonSerialized]  public bool hasGloves = false;

    // Detect if object enters the gbox collider
    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER ON THE GBOX IS SET TO "TRIGGER"!
    {
        if ( (other.gameObject.name == leftCollider.name || other.gameObject.name == rightCollider.name ) && !hasGloves && highlighted) // make sure object entering is the hands, and dont already have gloves
        {
            GameObject manager = GameObject.FindGameObjectWithTag("Manager");
            manager.GetComponent<createSmoke>().spawnSmoke(gameObject.transform);

            print(other.gameObject.name + "glove box triggered");
            SkinnedMeshRenderer meshRendererLeft = handLeft.GetComponent<SkinnedMeshRenderer>(); // get the meshRenderer component from the hand(s)
            SkinnedMeshRenderer meshRendererRight = handRight.GetComponent<SkinnedMeshRenderer>(); // get the meshRenderer component from the hand(s)

            meshRendererLeft.material.mainTexture = gloveTex; // set lefthand texture
            meshRendererRight.material.mainTexture = gloveTex; // set righthand texture

            handLeftFist.GetComponent<SkinnedMeshRenderer>().material.mainTexture = gloveTex;
            handRightFist.GetComponent<SkinnedMeshRenderer>().material.mainTexture = gloveTex;

            logData.writeLine("Put gloves on");

            highlighted = false;
            hasGloves = true;
            gameObject.GetComponent<highlight2>().unhighlightObj(); // remove highlight
            manager.GetComponent<controlSlides>().hasGloves = true;
            manager.GetComponent<controlSlides>().enableNext(); // update glove status in manager!
        }
    }

}
