using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gloveBox : MonoBehaviour
{

    public GameObject handLeft;
    public GameObject handRight;
    public GameObject leftCollider;
    public GameObject rightCollider;
    //public Material gloveMat;
    public Texture gloveTex;

    private bool hasGloves = false;

    // Detect if object enters the gbox collider
    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER ON THE GBOX IS SET TO "TRIGGER"!
    {
        if ( (other.gameObject.name == leftCollider.name || other.gameObject.name == rightCollider.name) && !hasGloves ) // make sure object entering is the hands, and dont already have gloves
        {
            print(other.gameObject.name + "glove box triggered");
            SkinnedMeshRenderer meshRendererLeft = handLeft.GetComponent<SkinnedMeshRenderer>(); // get the meshRenderer component from the hand(s)
            SkinnedMeshRenderer meshRendererRight = handRight.GetComponent<SkinnedMeshRenderer>(); // get the meshRenderer component from the hand(s)

            meshRendererLeft.material.mainTexture = gloveTex; // set lefthand texture
            meshRendererRight.material.mainTexture = gloveTex; // set righthand texture

            hasGloves = true;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().setGlove(); // update glove status in manager!

            //meshRendererLeft.materials[0] = gloveMat; // apply the gloveMaterial reference
            //meshRendererRight.materials[0] = gloveMat; // apply the gloveMaterial reference
        }
    }

}
