using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpsBin : MonoBehaviour
{
    [SerializeField] private GameObject lanceRef;
    [SerializeField] private GameObject rightHand;
    public logData logRef;
    public bool canDelete = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == lanceRef && canDelete)
        {

            //lanceRef.SetActive(false);
            //lanceRef.GetComponent<OVRGrabbable>().enabled = false; // turn off the OVRGrabbable script

            //print(rightHand.GetComponent<OVRGrabber>().grabbedObject.gameObject.name);

            //rightHand.GetComponent<OVRGrabber>().ForceRelease(lanceRef.GetComponent<OVRGrabbable>());
            logRef.writeLine("Put lancet in sharps bin");
            deleteGrabbed(lanceRef);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().sharpsTrash();
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSound>().Play("whoosh");
            //print(rightHand.GetComponent<OVRGrabber>().grabbedObject.gameObject.name);

            //lanceRef.SetActive(false);
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);

            //OVRGrabber grabber = lanceRef.GetComponent<OVRGrabbable>().grabbedBy;


            //grabber.ForceRelease(lanceRef.GetComponent<OVRGrabbable>());

            //if (grabber != null) {
            //    grabber.ForceRelease(grabber.grabbedObject);
            //}
            //
            //lanceRef.SetActive(false);
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);

            //if (!lanceRef.GetComponent<OVRGrabbable>().isGrabbed)
            //{
            //    //Destroy(lanceRef); FIX THIS
            //    //lanceRef.SetActive(false);
            //
            //    print("shouldnt be grabbed");
            //    lanceRef.GetComponent<OVRGrabbable>().GrabEnd(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            //    //lanceRef.SetActive(false);
            //    GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
            //
            //    //GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
            //} else
            //{
            //    print("is grabbed!");
            //    
            //
            //    lanceRef.GetComponent<OVRGrabbable>().GrabEnd(new Vector3(0,0,0), new Vector3(0, 0, 0));
            //    lanceRef.SetActive(false);
            //    GameObject.FindGameObjectWithTag("Manager").GetComponent<createSmoke>().spawnSmoke(gameObject.transform);
            //}
            //lanceRef.SetActive(false);
        }
    }

    private void deleteGrabbed(GameObject obj) // this was honestly the best solution for deleting a held object, and it saddens me greatly
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; // make it immovable
        obj.gameObject.transform.position = new Vector3(-100, -100, -100); // teleport it far away
    }
}

