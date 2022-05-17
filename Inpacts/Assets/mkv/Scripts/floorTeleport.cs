using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorTeleport : MonoBehaviour
{
    public GameObject[] objects;
    private Vector3[] startPositions;

    // Start is called before the first frame update
    void Start()
    {
        startPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            startPositions[i] = objects[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other) // MAKE SURE THE COLLIDER IS SET TO "TRIGGER"!
    {
        //print("trigger entered by: " + other.gameObject.name);
        for (int i = 0; i < objects.Length; i++)
        {
            //print(objects[i].gameObject.name);
            if(other.gameObject.name == objects[i].name)
            {
                print("found match w/: " + objects[i].name);
                objects[i].transform.position = startPositions[i];
            }
        }
    }
}
