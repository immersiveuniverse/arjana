using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAuditScore : MonoBehaviour {

	public int score = 10;
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		Debug.Log (score);
	}
}
