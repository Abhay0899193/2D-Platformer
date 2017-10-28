using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour {

	public GameObject[] Fires;



	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag("Player")) 
		{
			
				for (int i = 0; i < Fires.Length; i++) {
					Fires [i].SetActive (true);


			}

		}
	}
}
