using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour {

	public void ShowAd(){
		//Advertisement.Initialize("2772731");
		Advertisement.Show ();
		SceneManager.LoadScene("SceneMain");
	}
}
