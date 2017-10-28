using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad  {

	public static void SavePlayer(GM gm)
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream streem = new FileStream (Application.persistentDataPath + "/Lol.abh", FileMode.Create);
		playerData data = new playerData (gm);
		bf.Serialize (streem, data);
		streem.Close ();
	}

	public static float[] LoadPlayer()
	{
		if (File.Exists (Application.persistentDataPath + "/Lol.abh")) {
		
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream streem = new FileStream (Application.persistentDataPath + "/Lol.abh", FileMode.Open);
			playerData data = bf.Deserialize (streem)as playerData;
			streem.Close ();
			return data.stats;
		} else {
			Debug.Log("NO file Exists");
			return new float[7];
		}
	}
}
[Serializable]
public class playerData
{
	public float[] stats;
	public playerData(GM gm)
	{
		stats = new float[7];
		stats [0] = gm.golds;
		stats [1] = gm.darkMatter;
		stats [2] = gm.playerTransform.position.x;
		stats [3] = gm.playerTransform.position.y;
		stats [4] = gm.playerTransform.position.z;
		stats [5] = gm.powerLevel;
		stats [6] = gm.SN;

	}
}