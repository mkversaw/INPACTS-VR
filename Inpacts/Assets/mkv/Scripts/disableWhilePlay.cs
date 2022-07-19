using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableWhilePlay : MonoBehaviour
{

    AudioSource toCheck;
    public bool active = false;

    private void Start()
    {
        toCheck = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioSource>();
    }
    void Update()
    {
        if(active && toCheck.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<Button>().enabled = false;
        } else if (active)
        {
            this.GetComponent<Button>().enabled = true;
        }
    }
}
