using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {


	public float powerLevel = 0f;
	public bool key=false;
	public GameObject player;
	public float golds = 0f;
	public float darkMatter = 0f;
	public Transform playerTransform;
	public Text goldText;
	public Text DarkMatterText;
	public Transform PlayerStartingPosition;

	public int SN;

	void Start()
	{
		Load ();
	}

	public void kEY()
	{
		key = true;
	}
	public bool K()
	{
		return key;
	}
	public void Gold(float value)
	{
		golds += value;
		goldText.text = golds.ToString ();
		//Debug.Log ("Your Golds : " + golds.ToString ());
	}
	public void DarkMatter(float value)
	{
		darkMatter += value;
		DarkMatterText.text = darkMatter.ToString ();
	//	Debug.Log ("Your Dark Matter : " + darkMatter.ToString ());
	}
	public void Save(Transform p , int SceneNumber)
	{
		playerTransform = p;
		SN = SceneNumber;
		SaveLoad.SavePlayer (this);
	}
	public void Load()
	{
		float[] loadedStats = SaveLoad.LoadPlayer ();
		golds = loadedStats [0];
		darkMatter = loadedStats [1];
		playerTransform.position = new Vector3 (loadedStats [2], loadedStats [3], loadedStats [4]);
		Power (loadedStats [5]);
		Gold (0f);
		DarkMatter (0f);
		PlayerPostion ();
		SN = Mathf.FloorToInt (loadedStats [6]);
	}
	void PlayerPostion()
	{
		if (playerTransform.position == new Vector3 (0, 0, 0)) {
			//player.transform.position = PlayerStartingPosition.position;

			return;
		}
		player.transform.position = playerTransform.position;
	}
	public void Power(float powerL)
	{
		powerLevel = powerL;
	}
}
