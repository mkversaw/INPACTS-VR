using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStrip : MonoBehaviour
{
    [SerializeField] private GameObject bloodRef;
    //[SerializeField] private GameObject bloodCollider;
    [SerializeField] private GameObject textRef;
    [SerializeField] private GameObject thisRef; // ???
    [SerializeField] private floorTeleport floorTeleRef;

    public bool canTouch = false;
    bool touchedBlood = false;

    public void Update()
    {
        if(this.transform.position.y < 0) // prevent from falling
        {
            floorTeleRef.resetObject(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bloodRef && !touchedBlood && canTouch)
        {
            print("test strip touched blood!");
            thisRef.GetComponent<basemapSequencer>().startSequence();
            Destroy(bloodRef);
            textRef.SetActive(true);

            touchedBlood = true;

            

            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().enableNext(); // update status in manager
            GameObject.FindGameObjectWithTag("Manager").GetComponent<controlSlides>().stripTouchedBlood = true; // update status in manager
        }
    }
}
