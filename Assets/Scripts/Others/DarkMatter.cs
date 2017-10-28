using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatter : MonoBehaviour {

	public float value = 1f;
	public GM gm;

	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag("Player")) 
		{
			gm.DarkMatter (value);
			Destroy (gameObject);
		}
	}
}
