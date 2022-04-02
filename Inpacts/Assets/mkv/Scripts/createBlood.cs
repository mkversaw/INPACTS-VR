using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlood : MonoBehaviour
{

    public GameObject bloodObject;
    public GameObject lance;

    void Start()
    {
        bloodObject.GetComponent<Renderer>().enabled = false; // disable blood drop renderer on start up
    }

    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER IS SET TO "TRIGGER"!
    {
        print("trigger entered by: " + other.gameObject.name);

        if (other.gameObject.name == lance.name)
        {
            print("lance collision detected, enabling blood drop");
            bloodObject.GetComponent<Renderer>().enabled = true; // enable it on collision with lance
        }
    }

}
