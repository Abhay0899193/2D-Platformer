using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void ReTry()
	{
		float[] loadedStats = SaveLoad.LoadPlayer ();
		int scenN = Mathf.FloorToInt (loadedStats [6]);
		Application.LoadLevel (scenN);
	}
}
