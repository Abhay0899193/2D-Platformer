using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlugMovement : MonoBehaviour {


	public GameObject enemy;
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
		if (enemy == null) {
			return;
		}
		enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, currentPosition.position, movingSpeed * Time.deltaTime);
		if (enemy.transform.position == currentPosition.position) 
		{
			pointer++;
			if (pointer == points.Length) 
			{
				pointer = 0;
			}
			currentPosition = points [pointer];
			flip ();
		}
	}

	void flip()
	{
		Vector3 theScale = enemy.transform.localScale;
		theScale.x *= -1;
		enemy.transform.localScale = theScale;
	}
}
