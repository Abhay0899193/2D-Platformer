using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

	public float power = 1f;
	public GM gm;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			gm.Power (power);
			Destroy (gameObject);
		}
	}

}
