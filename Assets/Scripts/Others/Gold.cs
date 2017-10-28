using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

	public float value = 10f;
	public GM gm;

	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag("Player")) 
		{
			gm.Gold (value);
			Destroy (gameObject);
		}
	}
}
