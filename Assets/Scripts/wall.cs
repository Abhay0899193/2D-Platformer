using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {

	public GameObject wallExplosition; 

	public void DestroyWall()
	{
		Instantiate (wallExplosition, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
