using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpsBin : MonoBehaviour
{
    [SerializeField] private GameObject lanceRef;
    public bool canDelete = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == lanceRef && canDelete)
        {
            //if (!lanceRef.GetComponent<OVRGrabbable>().isGrabbed)
            //{
            //    //Destroy(lanceRef); FIX THIS
            //    lanceRef.SetActive(false);
            //}
            GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
            lanceRef.SetActive(false);
        }
    }
}
