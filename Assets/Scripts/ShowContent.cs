using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowContent : MonoBehaviour {

	public Text showHint;
	public void AfterPaying(){
		showHint.gameObject.SetActive (true);
	}
}
