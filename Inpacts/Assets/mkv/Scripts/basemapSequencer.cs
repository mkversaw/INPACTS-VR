using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animates a given renderer's material through a pre-set list of textures. Can also set the delay between each texture
/// </summary>
public class basemapSequencer : MonoBehaviour
{
    public Renderer rend; // the object's renderer component
    public Texture[] sequence; // the list of sprites/textures the sequence should go through

    private IEnumerator startSeq(float delay) // delay between pngs
    {
        print("STARTED PNG SEQUENCE!");
        foreach (Texture tex in sequence) {
            rend.material.SetTexture("_BaseMap", tex); // update the renderer's material with the new texture every (delay) seconds
            yield return new WaitForSeconds(delay);
        }
    }

    public void startSequence(float delay = 0.05f)
    {
        StartCoroutine(startSeq(0.05f));
    }

    private void OnApplicationQuit() // this resets the renderer's material so no permanent changes occur
    {
        if (sequence.Length > 0)
        {
            rend.material.SetTexture("_BaseMap", sequence[0]);
        }
    }
}
