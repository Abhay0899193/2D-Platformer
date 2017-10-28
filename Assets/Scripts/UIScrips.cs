using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScrips : MonoBehaviour {


	public Text GoldText;
	public Text DarkMatterText;

	private int sn;

	// Use this for initialization
	void Start () {
		Load ();
	}
	
	public void Load()
	{
		float[] loadedStats = SaveLoad.LoadPlayer ();
		GoldText.text = loadedStats [0].ToString ();
		DarkMatterText.text = loadedStats [1].ToString ();
		sn=Mathf.FloorToInt (loadedStats [6]);
		//golds = loadedStats [0];
	//	darkMatter = loadedStats [1];
	//	playerTransform.position = new Vector3 (loadedStats [2], loadedStats [3], loadedStats [4]);
	//	Power (loadedStats [5]);
		//Gold (0f);
	//	DarkMatter (0f);
		//PlayerPostion ();
	}
	public void Next()
	{
		Application.LoadLevel (++sn);
	}
}
