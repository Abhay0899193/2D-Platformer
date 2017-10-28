using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public int Ammount = 10;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			other.gameObject.GetComponent<PlayerHealth> ().takeDamage (Ammount);
		}
	}
}
