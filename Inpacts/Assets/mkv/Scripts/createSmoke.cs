using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createSmoke : MonoBehaviour
{
	[SerializeField] private GameObject smokeRef;
	IEnumerator smoke(Transform parentTrans)
	{
		GameObject temp = Instantiate(smokeRef, parentTrans.position, Quaternion.identity); // make the smoke
		temp.SetActive(true);
		yield return new WaitForSeconds(1); // let it finish playing
		Destroy(temp); // delete it
	}

	public void spawnSmoke(Transform parentTrans)
	{
		StartCoroutine(smoke(parentTrans));
	}
}
