using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpsBin : MonoBehaviour
{
    [SerializeField] private GameObject lanceRef;
    public bool canDelete = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == lanceRef && canDelete)
        {
            Destroy(lanceRef);
        }
    }
}
