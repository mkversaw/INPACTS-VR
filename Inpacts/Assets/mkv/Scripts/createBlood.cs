using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlood : MonoBehaviour
{

    public GameObject bloodObject;
    public GameObject lance;
    private bool madeBlood = false;

    void Start()
    {
        gameObject.SetActive(false);
        //bloodObject.GetComponent<Renderer>().enabled = false; // disable blood drop renderer on start up
        bloodObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER IS SET TO "TRIGGER"!
    {
        //print("trigger entered by: " + other.gameObject.name);

        if (other.gameObject.name == lance.name && !madeBlood)
        {
            print("lance collision detected, enabling blood drop");
            madeBlood = true;
            //bloodObject.GetComponent<Renderer>().enabled = true; // enable it on collision with lance
            this.GetComponent<Renderer>().enabled = false; // disable highlight renderer

            bloodObject.SetActive(true); // enable it on collision with lance

            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().pricked = true;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager

            gameObject.SetActive(false);
        }
    }

}
