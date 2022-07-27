using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTeleport : MonoBehaviour
{
    public GameObject[] objs;

    private Vector3[] originalPositions;
    private Quaternion[] originalRotations;

    // Start is called before the first frame update
    void Start()
    {
        originalPositions = new Vector3[objs.Length]; // create a list of vector3s the same size as there are objects in objs
        originalRotations = new Quaternion[objs.Length]; 

        for(int i = 0; i < objs.Length; i++) // for each object in the list
        {
            originalPositions[i] = objs[i].transform.position; // save its position as a vector3 to another list
            originalRotations[i] = objs[i].transform.rotation; // save its position as a vector3 to another list
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        for(int i = 0; i < objs.Length; i++) // for each object
        {
            if(collision.gameObject == objs[i]) // check the collided obj to see if its in the list
            {
                print("resetting the position of: " + objs[i].gameObject.name);
                objs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                objs[i].GetComponent<Rigidbody>().isKinematic = true;
                objs[i].transform.position = originalPositions[i]; // if its in the list then reset its position
                objs[i].transform.rotation = originalRotations[i]; //
                objs[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        
    }

    
}
