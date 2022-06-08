using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlood : MonoBehaviour
{

    public GameObject bloodObject;
    public GameObject lance;
    private bool madeBlood = false;

    private bool doScale = true;

    private float finalScale;
    private float startScale;
    private float elapsedTime = 0;

    void Start()
    {
        gameObject.SetActive(false);
        //bloodObject.GetComponent<Renderer>().enabled = false; // disable blood drop renderer on start up
        finalScale = bloodObject.transform.localScale.x; // this is the MAX size the drop should become
        startScale = finalScale / 10.0f;

        bloodObject.transform.localScale = new Vector3(startScale, startScale, startScale);

        if(bloodObject.transform.localScale.x != bloodObject.transform.localScale.y || bloodObject.transform.localScale.x != bloodObject.transform.localScale.z || bloodObject.transform.localScale.y != bloodObject.transform.localScale.z)
        {
            print("BLOOD SHOULD HAVE A UNIFORM SCALE!!!!!");
        }

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

            doScale = true;

            bloodObject.SetActive(true); // enable it on collision with lance

            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().pricked = true;
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager

            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (doScale && elapsedTime < 4.0f)
        {
            float newScale = Mathf.Lerp(startScale, finalScale, (elapsedTime / 4.0f));
            elapsedTime += Time.deltaTime;
            bloodObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
