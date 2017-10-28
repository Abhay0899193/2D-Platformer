using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public GM gm;
	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag("Player")) 
		{
			gm.kEY ();
			Destroy (gameObject);
		}
	}
}
