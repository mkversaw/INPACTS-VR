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
				objs[i].SetActive(false);
			}
		}
	}

}
