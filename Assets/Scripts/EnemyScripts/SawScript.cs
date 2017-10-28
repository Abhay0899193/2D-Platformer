using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour {

	public int Ammount = 10;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			other.gameObject.GetComponent<PlayerHealth> ().takeDamage (Ammount);
		}
	}
}
