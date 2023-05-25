using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlood : MonoBehaviour
{

    public GameObject lance;
    private bool madeBlood = false;
    public logData logRef;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER IS SET TO "TRIGGER"!
    {

        if (other.gameObject.name == lance.name && !madeBlood)
        {

            GetComponent<SphereCollider>().radius = 2.0f; // increase size of hitbox now!!!

            print("lance collision detected, enabling blood drop");
            madeBlood = true;

            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSound>().Play("whoosh");
            logData.writeLine("Patient finger pricked");
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().pricked = true;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager

        }
    }
}
