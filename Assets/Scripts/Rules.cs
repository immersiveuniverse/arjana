using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour {

	public GameObject panelRules, btnHowTo, btnClosePanel;

	public void ShowRules(){
		panelRules.SetActive (true);
	}

	public void CloseRules(){
		panelRules.SetActive (false);
	}
}
