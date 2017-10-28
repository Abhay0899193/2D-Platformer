using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoundary : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			other.gameObject.GetComponent<PlayerHealth> ().takeDamage (100);
		}
	}
}
