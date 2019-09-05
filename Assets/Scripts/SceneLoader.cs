using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class SceneLoader : MonoBehaviour {
	public GameObject panelCongo, panelTime;
	public GameObject PanelWarning;

	public Image FadeInOut;
	public Animator FadeInOutAnim;

	void Start(){
		FadeInOut.gameObject.SetActive (true);
	}

	public void EnablePanelWarning(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PanelWarning.SetActive (false);
		} else {
			PanelWarning.SetActive (true);
		}
	}

	public void StayGameYes() {
		PanelWarning.SetActive (false);
	}

	public void StayGameNo(){
		Debug.Log ("Quit");
		Application.Quit ();
	}

	public void LoadScene(string scenename){
		SceneManager.LoadScene(scenename);
	}

	public void LoadScene(int sceneindex){
		SceneManager.LoadScene(sceneindex);
		if (SceneManager.GetActiveScene ().buildIndex > 1) {
			
		}
	}

	void Update(){
		if (FadeInOut.color.a == 0) {
			FadeInOut.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (SceneManager.GetActiveScene ().buildIndex > 1) {
				Debug.Log(SceneManager.GetActiveScene ().buildIndex);
				SceneManager.LoadScene (1);
			} else if (SceneManager.GetActiveScene ().buildIndex <= 1) {
				Application.Quit();	
			}
		}
	}

	public void ExitApp(){
		Application.Quit();
	}

	public void LoadTimeMoney(){
		Destroy (panelCongo);
		panelTime.SetActive (true);
	}

	public void ShowAdEntreprenuer(){
		//Advertisement.Initialize("2772731");
		Advertisement.Show ();
		SceneManager.LoadScene("SceneEntreprenuer");
	}

	public void ShowAdDoer(){
		//Advertisement.Initialize("2772731");
		Advertisement.Show ();
		SceneManager.LoadScene("SceneDoer");
	}
}

