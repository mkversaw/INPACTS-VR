using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basemapSequencer : MonoBehaviour
{
    //public Material matRef;
    public Renderer rend;
    public Texture[] sequence;

    private void Start()
    {
        // DEBUG PURPOSES ONLY!
        //StartCoroutine(startSeq(0.05f)); // RE-COMMENT WHEN DONE
    }
    private IEnumerator startSeq(float delay) // delay between pngs
    {
        print("STARTED PNG SEQUENCE!");
        foreach (Texture tex in sequence) {

            //matRef.SetTexture("_BaseMap", tex);
            rend.material.SetTexture("_BaseMap", tex);

            yield return new WaitForSeconds(delay);
        }
    }

    public void startSequence(float delay = 0.05f)
    {
        StartCoroutine(startSeq(0.05f));
    }

    private void OnApplicationQuit()
    {
        if (sequence.Length > 0)
        {
            rend.material.SetTexture("_BaseMap", sequence[0]);
            print("set to: " + sequence[0].name);
        }
    }
}
