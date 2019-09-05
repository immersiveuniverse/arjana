using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class FallController : MonoBehaviour {

	Scene scene;
	void OnTriggerEnter(){
		ShowAd ();
	}

	void ShowAd(){
		Advertisement.Show ();
		Debug.Log ("Play Ads");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
