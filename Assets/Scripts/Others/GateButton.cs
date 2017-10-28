using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour {

	public GameObject Gate;
	public Transform ButtonPosition;
	public Transform GatePosition;
	//public float moveSpeed = 2f;
	public Transform startButtonposition;
	public Transform StartGatePosition;





	void OnTriggerEnter2D(Collider2D O)
	{
		if (O.gameObject.CompareTag ("Player") || O.gameObject.CompareTag ("Box"))
		{
			//transform.position = Vector3.Lerp (transform.position, ButtonPosition.position, Time.deltaTime * moveSpeed);
			transform.position = ButtonPosition.position;
			//Gate.transform.position = Vector3.Lerp (Gate.transform.position, GatePosition.position, Time.deltaTime * moveSpeed);
			Gate.transform.position=GatePosition.position;
		}
	}

	void OnTriggerExit2D(Collider2D O)
	{
		if (O.gameObject.CompareTag ("Player") || O.gameObject.CompareTag ("Box"))
		{

			//transform.position = Vector3.Lerp (transform.position, startButtonposition.position, Time.deltaTime * moveSpeed);
			//Gate.transform.position = Vector3.Lerp (Gate.transform.position, StartGatePosition.position, Time.deltaTime * moveSpeed);

			transform.position = startButtonposition.position;
			Gate.transform.position = StartGatePosition.position;
		}
	}
}
