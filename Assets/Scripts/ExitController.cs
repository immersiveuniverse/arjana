using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour {

	public GameObject PanelWarning, MenuDisplay;

	public void EnablePanelWarning(){
		PanelWarning.SetActive (true);
		MenuDisplay.SetActive (false);
	}

	public void StayGameYes() {
		PanelWarning.SetActive (false);
		MenuDisplay.SetActive (true);
	}

	public void StayGameNo(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
