using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explostion : MonoBehaviour {
	
	public float time = 0.8f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, time);
	}

}