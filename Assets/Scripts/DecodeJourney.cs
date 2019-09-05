using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class DecodeJourney : MonoBehaviour {

	public InputField decode;
	public GameObject hint;
	public Button btnCan;

	public GameObject finalLadder, decodeBlock, person, dummyCamera;
	public Transform character;

	private string encodedString;
	private string decodedString = "ican";

	private Transform value;
	private float decodeBlockValueX = 65f;
	private float decodeBlockValueXX = 67f;
	private float decodeBlockValueY = -5.5f;
	private int i = 0;

	void Start(){
		value = character.GetComponent<Transform> ();
		Debug.Log (value);
	}

	void Update(){
		if (value.position.x >= decodeBlockValueX && value.position.x <= decodeBlockValueXX && i==0){
			i++;
			decode.gameObject.SetActive (true);
			hint.SetActive (true);
			btnCan.gameObject.SetActive (true);
		}	
	}

	private float newX=72f, newY=0f;

	public void OnEnd(){
		encodedString = decode.text;
		encodedString = Regex.Replace(encodedString, @"[^0-9a-zA-Z]+", "").ToLower();
		if (encodedString.Equals (decodedString)) {
			decode.gameObject.SetActive (false);
			decodeBlock.SetActive (false);

			btnCan.gameObject.SetActive (false);
			finalLadder.SetActive (true);

			person.transform.position = new Vector3 (newX, newY, 0.0f);
		} else {
			decode.text = "";
			decode.placeholder.GetComponent<Text>().text = "Wrong! Try Again";
			SceneManager.LoadScene("SceneDoer");
		}
	}
		
}
