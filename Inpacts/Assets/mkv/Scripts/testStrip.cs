using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStrip : MonoBehaviour
{
    [SerializeField] private GameObject bloodRef;
    //[SerializeField] private GameObject bloodCollider;
    [SerializeField] private GameObject textRef;

    bool touchedBlood = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == bloodRef)
        {
            Destroy(bloodRef);
            textRef.SetActive(true);
            touchedBlood = true;
        }
    }
}
