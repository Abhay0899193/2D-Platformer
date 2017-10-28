using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {


	public GameObject Platform;
	public float movingSpeed = 5f;
	public Transform[] points;
	public int pointer;

	private Transform currentPosition;


	// Use this for initialization
	void Start () {
		currentPosition = points[pointer];
	}
	
	// Update is called once per frame
	void Update () {
		Platform.transform.position = Vector3.MoveTowards (Platform.transform.position, currentPosition.position, movingSpeed * Time.deltaTime);
		if (Platform.transform.position == currentPosition.position) 
		{
			pointer++;
			if (pointer == points.Length) 
			{
				pointer = 0;
			}
			currentPosition = points [pointer];
		}
	}
}
