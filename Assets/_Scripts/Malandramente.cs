using UnityEngine;
using System.Collections;

public class Malandramente : MonoBehaviour {

	public AudioClip audioMalandramente;
    
	void Awake () {
		audioMalandramente= GetComponent<AudioClip>();
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (audioMalandramente, transform.position);
			Destroy (gameObject);
		}
	}

}
