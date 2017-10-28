using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {
	
	public GM gm;
	public Transform playertransform;
	public int ScenNo = 0;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			gm.Save (playertransform, ScenNo);
			Debug.Log ("Data Saved");
		}
	}
}
