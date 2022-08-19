using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearObjects : MonoBehaviour
{
	/// <summary>
	/// A round-about way to delete objects without truly deleting them.
	/// This fixes a problem where the OVR hands can't handle held objects being deleted
	/// </summary>
	[SerializeField] private GameObject[] objs;

	public void clear()
	{
		for(int i = 0; i < objs.Length; i++)
		{
			if(objs[i] != null)
			{
				// objs[i].transform.parent = null; // !
				objs[i].GetComponent<Rigidbody>().isKinematic = true; // make it immovable
				objs[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; // make it immovable
				objs[i].gameObject.transform.position = new Vector3(-100, -100, -100); // teleport it far away
				objs[i].gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f); // shrink it to be super small
			}
		}
	}

}
