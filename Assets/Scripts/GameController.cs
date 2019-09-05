using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject BtnExplore, PanelNotice, FpsController, DummyCamera, LockKey, LockKeyCount;
	public GameObject MobileController;
	public int unlockLevel;

	public void ExploreStudent(){
		Destroy(BtnExplore);
		Destroy(PanelNotice);

		FpsController.gameObject.SetActive(true);
		DummyCamera.gameObject.SetActive(false);
		MobileController.SetActive (true);

		if(SceneManager.GetActiveScene().name != "SceneDoer"){
			LockKey.SetActive (true);
			LockKeyCount.SetActive (true);
		}

	}

	public void WinLevel(){
		if (unlockLevel > PlayerPrefs.GetInt ("LevelReached", 1)) {
			PlayerPrefs.SetInt ("LevelReached", unlockLevel);
		}
		Debug.Log (unlockLevel);
	}
}

