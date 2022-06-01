using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTeleport : MonoBehaviour
{
    public GameObject lancetRef;
    public GameObject glucometerRef;
    public GameObject testStripRef;

    private Vector3 lancetStart;
    private Vector3 glucometerStart;
    private Vector3 testStripStart;

    // Start is called before the first frame update
    void Start()
    {
        lancetStart = lancetRef.transform.position;
        glucometerStart = glucometerRef.transform.position;
        testStripStart = testStripRef.transform.position;
        
    }

    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER IS SET TO "TRIGGER"!
    {
        if(other.CompareTag(lancetRef.tag))
        {
            lancetRef.transform.position = lancetStart;
        } else if (other.CompareTag(glucometerRef.tag))
        {
            glucometerRef.transform.position = glucometerStart;
        } else if (other.CompareTag(testStripRef.tag))
        {
            testStripRef.transform.position = testStripStart;
        }
    }
}
