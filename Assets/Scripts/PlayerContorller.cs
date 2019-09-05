using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Advertisements;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class PlayerContorller : MonoBehaviour {
		
	public GameObject fpc;
	public GameObject[] Lessons;
	public GameObject BtnContinue;
	public GameObject DummyCamera;
	public GameObject Win;
	public GameObject Path;

	public GameObject BtnObjects, MobileController, LockKeyParent, LockKeyCount, KeyLockContainer;
	public GameController gameController;

	private int gemsCounter=0;
	public AudioClip GemClipSound;

	public Image[] LockKey;
	public Sprite fillKey;

	// Generate Random Range
	private List<int> randomList = new List<int>();
	private int numToAdd;

	public Text keyQuote;
	public Button[] keyButtons;

	public void OnTriggerEnter(Collider other){
		

		if (other.gameObject.CompareTag ("Gems")) {
			
			GetComponent<AudioSource> ().clip = GemClipSound;
			GetComponent<AudioSource> ().Play ();

			Destroy (other.gameObject);
			fpc.SetActive(false);
			DummyCamera.SetActive (true);
			LockKeyParent.SetActive (false);
			LockKeyCount.SetActive (false);

			numToAdd = Random.Range (0,11);	
			//Debug.Log ("Generate - "+numToAdd.ToString());
			while(randomList.Contains(numToAdd)){
				numToAdd = Random.Range (0, 11);
				//Debug.Log ("While - "+numToAdd.ToString());
			}
			randomList.Add (numToAdd);

			Lessons [numToAdd].gameObject.SetActive (true); 
			LockKey[gemsCounter].GetComponent<Image>().sprite = fillKey;
			gemsCounter++;	// 0; 1;

			BtnContinue.gameObject.SetActive (true);

		}else if(other.gameObject.CompareTag ("TrophyTag")){

			Destroy (other.gameObject);
			fpc.SetActive(false);
			DummyCamera.SetActive (true);
			Destroy (Path);

			Lessons [0].gameObject.SetActive (true); 

		}
	}



	public void Continue(){
		Lessons [numToAdd].gameObject.SetActive(false);	// 10; 11;
		//Debug.Log ("Destroy - "+numToAdd.ToString());
		foreach(int i in randomList){
			Debug.Log("Random Number " + i);	
		}
		Debug.Log ("Index of Random Number " + randomList.IndexOf(numToAdd));

		fpc.SetActive(true);
		DummyCamera.SetActive (false);
		BtnContinue.gameObject.SetActive (false);
		LockKeyParent.SetActive (true);
		LockKeyCount.SetActive (true);
		if (gemsCounter > 10) {
			//OnWin ();
			if (SceneManager.GetActiveScene ().name == "SceneStudent") {
				StudentLevelQuiz ();	
			}
			if (SceneManager.GetActiveScene ().name == "SceneEmployee") {
				EmployeeLevelQuiz ();	
			}
			if (SceneManager.GetActiveScene ().name == "SceneEntreprenuer") {
				EntreprenuerLevelQuiz ();
			}
		}
	}

	public void OnWin(){
		Destroy (BtnObjects);
		Destroy (MobileController);
		Destroy (KeyLockContainer);
		Win.gameObject.SetActive (true);
	}


	string[] levelOne = {"learn", "aim", "investment", "change", "create", "difference", "habit", "meets", "thoughts", "something", "meant"};
	int key;
	string quote;

	public void StudentLevelQuiz(){
		key = 0;
		quote = "";
		MobileController.SetActive (false);
		LockKeyParent.SetActive (false);
		LockKeyCount.SetActive (false);

		KeyLockContainer.SetActive (true);
		key = Random.Range (0, 11);	
		quote = Lessons [key].GetComponentInChildren<Text>().text;

		keyQuote.text ="\" "+ quote+" \"";
		Debug.Log (key);
		Debug.Log (quote);
		Debug.Log (randomList.IndexOf (key));
	}

	int numberOfTry = 3;
	public Image TryLeftImage;
	public Image LockUnlock;
	public Text TryLeftText;

	public void StudentLevelKey(int keyButtonsIndex){
		if (numberOfTry > 0) {
			if (randomList.IndexOf (key) == keyButtonsIndex) {
				LockUnlock.GetComponent<Animation> ().Play();
				Debug.Log ("You Win");	
				//OnWin ();
				StartCoroutine("DisplayWin");
			} else {
				if (numberOfTry == 1) {
					numberOfTry--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTry.ToString ();
					Debug.Log ("Restart");
					SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				} else {
					Debug.Log ("Try Again");
					numberOfTry--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTry.ToString ();
				}
			}	
		}
	}

	string[] levelTwo = {"joy", "strong", "bridge", "career", "employee", "passionate", "cake", "hammer", "control", "done", "team"};
	public Image quoteImage;
	public Sprite[] quoteImageGroup;

	public void EmployeeLevelQuiz(){
		key = 0;
		quote = "";

		MobileController.SetActive (false);
		LockKeyParent.SetActive (false);
		LockKeyCount.SetActive (false);

		KeyLockContainer.SetActive (true);
		key = Random.Range (0, 11);	
		quote = levelTwo[key].ToLower();
		quoteImage.GetComponent<Image>().sprite = quoteImageGroup[key];

		keyQuote.text ="\" "+ quote+" \"";
		Debug.Log (key);
		Debug.Log (quote);
		Debug.Log (randomList.IndexOf (key));
	}

	int numberOfTryEmployee = 4;
	public void EmployeeLevelKey(int keyButtonsIndex){
		if (numberOfTryEmployee > 0) {
			if (randomList.IndexOf (key) == keyButtonsIndex) {
				LockUnlock.GetComponent<Animation> ().Play();
				Debug.Log ("You Win");	
				//OnWin ();
				StartCoroutine("DisplayWin");
			} else {
				if (numberOfTryEmployee == 1) {
					numberOfTryEmployee--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTryEmployee.ToString ();
					Debug.Log ("Restart");
					SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				} else {
					Debug.Log ("Try Again");
					numberOfTryEmployee--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTryEmployee.ToString ();
				}
			}	
		}
	}


	string[] levelThree = {"money", "rules", "starting", "people", "curve", "love", "vision", "entreprenuer", "stones", "success", "poison"};
	public Image quoteImageEnt;
	public Sprite[] quoteImageGroupEnt;

	public void EntreprenuerLevelQuiz(){
		key = 0;
		quote = "";

		MobileController.SetActive (false);
		LockKeyParent.SetActive (false);
		LockKeyCount.SetActive (false);

		KeyLockContainer.SetActive (true);
		key = Random.Range (0, 11);	
		quote = levelThree[key].ToLower();
		quoteImageEnt.GetComponent<Image>().sprite = quoteImageGroupEnt[key];

		keyQuote.text ="\" "+ quote+" \"";
		Debug.Log (key);
		Debug.Log (quote);
		Debug.Log (randomList.IndexOf (key));
	}

	int numberOfTryEntreprenuer = 3;
	public void EntreprenuerLevelKey(int keyButtonsIndex){
		if (numberOfTryEntreprenuer > 0) {
			if (randomList.IndexOf (key) == keyButtonsIndex) {
				LockUnlock.GetComponent<Animation> ().Play();
				Debug.Log ("You Win");	
				//OnWin ();
				StartCoroutine("DisplayWin");
			} else {
				if (numberOfTryEntreprenuer == 1) {
					numberOfTryEntreprenuer--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTryEntreprenuer.ToString ();
					Debug.Log ("Restart");
					SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				} else {
					Debug.Log ("Try Again");
					numberOfTryEntreprenuer--;
					TryLeftImage.GetComponent<Animation> ().Play();
					TryLeftText.GetComponent<Text>().text = numberOfTryEntreprenuer.ToString ();
				}
			}	
		}
	}

	IEnumerator DisplayWin(){
		yield return new WaitForSeconds (1.5f);
		OnWin ();
		gameController.WinLevel ();
	}
}
