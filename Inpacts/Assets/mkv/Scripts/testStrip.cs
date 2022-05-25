using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStrip : MonoBehaviour
{
    [SerializeField] private GameObject bloodRef;
    //[SerializeField] private GameObject bloodCollider;
    [SerializeField] private GameObject textRef;

    bool touchedBlood = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bloodRef && !touchedBlood)
        {
            print("test strip touched blood!");
            Destroy(bloodRef);
            textRef.SetActive(true);

            touchedBlood = true;

            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().stripTouchedBlood = true; // update status in manager
        }
    }
}
