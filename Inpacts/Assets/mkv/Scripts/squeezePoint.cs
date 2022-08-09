using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squeezePoint : MonoBehaviour
{
    public GameObject bloodObject;

    public GameObject pinchHandRef;
    public GameObject leftHandRef;
    public GameObject rightHandRef;
    public GameObject ghostHandRef;

    private bool doScale = true;

    private float finalScale;
    private float startScale;
    private float elapsedTime = 0;

    private bool wasGrabbed = false;
    void Start()
    {
        pinchHandRef.SetActive(false);
        bloodObject.SetActive(false);

        finalScale = bloodObject.transform.localScale.x; // this is the MAX size the drop should become
        startScale = finalScale / 10.0f;

        bloodObject.transform.localScale = new Vector3(startScale, startScale, startScale);

        if (bloodObject.transform.localScale.x != bloodObject.transform.localScale.y || bloodObject.transform.localScale.x != bloodObject.transform.localScale.z || bloodObject.transform.localScale.y != bloodObject.transform.localScale.z)
        {
            print("BLOOD SHOULD HAVE A UNIFORM SCALE!!!!!");
        }

    }

    IEnumerator enableSqueeze(bool right)
    {
        ghostHandRef.SetActive(false);
        pinchHandRef.SetActive(true);
        this.GetComponent<Renderer>().enabled = false; // disable highlight renderer

        bloodObject.SetActive(true);
        doScale = true;

        if (right)
        {
            print("right hand");
            rightHandRef.GetComponent<changeHand>().none();

            yield return new WaitForSeconds(2.0f);
            pinchHandRef.SetActive(false);
            rightHandRef.GetComponent<changeHand>().normal();
        } else
        {
            print("left hand");
            leftHandRef.GetComponent<changeHand>().none();

            yield return new WaitForSeconds(2.0f);
            pinchHandRef.SetActive(false);
            leftHandRef.GetComponent<changeHand>().normal();
        }

    }
    void Update()
    {
        if(!wasGrabbed && GetComponent<OVRGrabbable>().isGrabbed)
        {
            StartCoroutine(enableSqueeze(GetComponent<OVRGrabbable>().grabbedBy.gameObject.tag == "Right Hand"));
            wasGrabbed = true;
        }

        if (doScale && elapsedTime < 4.0f)
        {
            float newScale = Mathf.Lerp(startScale, finalScale, (elapsedTime / 4.0f));
            elapsedTime += Time.deltaTime;
            bloodObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
