using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableWhilePlay : MonoBehaviour
{

    AudioSource toCheck;
    GameObject manager;
    public bool active = false;
    public string toPlay;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        toCheck = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }
    void Update()
    {
        if(active && toCheck.isPlaying)
        {
            this.GetComponent<Button>().enabled = false;
        } else if (active)
        {
            this.GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator waitHelp()
    {
        this.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        this.GetComponent<Button>().enabled = true;
    }
    public void waitDisable()
    {
        toCheck.Stop();

        manager.GetComponent<controlSound>().Play(toPlay);

        StartCoroutine(waitHelp());
    }
}

