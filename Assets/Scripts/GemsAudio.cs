using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsAudio : MonoBehaviour {
	public AudioClip gemClip;
	AudioSource gemSource;
	public float volumeScale = 1f;

	void Start(){
		gemSource = GetComponent<AudioSource> ();
	}

	void PlayGemsSound(){
		gemSource.clip = gemClip;
		gemSource.Play ();
	}
}
