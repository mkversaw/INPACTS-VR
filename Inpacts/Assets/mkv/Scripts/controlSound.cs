using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // let this CLASS show up in the editor
public class Sound
{
	public AudioClip clip; // which sound file
	public string name; // name of that file
};
public class controlSound : MonoBehaviour
{

	public Sound[] sounds; // array of sounds
	public AudioSource source; // where to play the sounds


	public void Play(string soundName) // public so outside scripts can use it
	{
		foreach (Sound s in sounds)
		{
			if(s.name == soundName) // found the requested sound
			{
				source.PlayOneShot(s.clip);
				return;
			}
		}

		print("Could not find requested sound!"); // requested sound was not in array
	}


}
