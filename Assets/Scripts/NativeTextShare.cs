using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NativeTextShare : MonoBehaviour {

	string shareSubject = "Arjana - Perceive . Believe . Achieve";
	string shareMessage = "First of a kind, a Motivational Game in Apps History.\n" +
		"Introducing\n" +
		"\n" +
		"***** ARJANA *****\n" +
		"Perceive - Believe - Achieve\n" +
		"\n" +
		"This Game will definitely bring a Change, which you wants to have in your Life.\n" +
		"\n" +
		"Would you like to give it a try ?\n" +
		"If No, then you need it the most.\n" +
		"If Yes, then lets go and install the Game.\n" +
		"https://play.google.com/store/apps/details?id=com.ic.arjana";

	public void OnAndroidTextSharingClick()
	{

		StartCoroutine(ShareTextInAnroid());

	}


	IEnumerator ShareTextInAnroid () {
		yield return new WaitForEndOfFrame();
		#if UNITY_ANDROID
		if (!Application.isEditor) {
			//Create intent for action send
			AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
			intentObject.Call<AndroidJavaObject> 
			("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));

			//put text and subject extra
			intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
			intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), shareSubject);
			intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), shareMessage);

			//call createChooser method of activity class
			AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
			AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject> ("createChooser", intentObject, "Your Support Means A Lot | Thanks");
			currentActivity.Call ("startActivity", chooser);
		#endif
		}
	}
}