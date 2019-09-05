using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanksForBuying : MonoBehaviour {

	public GameObject panelThanks;
	public void ThankYouUser(){
		panelThanks.SetActive (true);
	}

	public void CloseThanks(){
		panelThanks.SetActive (false);
	}
}
