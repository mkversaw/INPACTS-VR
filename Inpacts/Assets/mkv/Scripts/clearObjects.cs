using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearObjects : MonoBehaviour
{
	[SerializeField] private GameObject[] objs;

	public void clear()
	{
		for(int i = 0; i < objs.Length; i++)
		{
			if(objs[i] != null)
			{
				//objs[i].SetActive(false);
				//objs[i].transform.position = new Vector3(-100, 100, 100);

				objs[i].transform.parent = null; // !
				objs[i].GetComponent<Rigidbody>().isKinematic = true;
				objs[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; // make it immovable
				objs[i].gameObject.transform.position = new Vector3(-100, -100, -100); // teleport it far away
				objs[i].gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
			}
		}
	}

}
