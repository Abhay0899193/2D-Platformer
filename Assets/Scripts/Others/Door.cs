using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GM gm;

	private Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag ("Player") && gm.K()) 
		{
			anim.SetTrigger ("Open");
		}
	}
}
