using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text timeMessage;
	public Text pickupsLeft;


	public float timer;
	public float speed;

	private string minutes;
	private string seconds;

	private Rigidbody player;
	private int totalPickups;

	private bool won;

	void Start() {
		
		player = GetComponent<Rigidbody> ();
		totalPickups = 25;
		won = false;
		pickupsLeft.text = "Pickups left: " + totalPickups.ToString();

		RecalculateTime ();

	}

	void Update () {
		RecalculateTime ();
	}

	void FixedUpdate() {
		
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis ("Vertical"); 

		Vector3 moviment = new Vector3 (moveHorizontal, 0, moveVertical);

		player.AddForce (moviment * speed);

	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag ("Pickup")) {

			other.gameObject.SetActive (false);

			RecalculatePickups (); 
		
		}
	}

	void RecalculateTime() {

		if (!won) {
			minutes = Mathf.Floor (Time.realtimeSinceStartup / 60).ToString ("00");
			seconds = (Time.realtimeSinceStartup % 60).ToString ("00");

			timeMessage.text = "Time: " + minutes + ":" + seconds;
		} else {
			timeMessage.text = "Time to collect all the pickups: " + minutes + ":" + seconds;
		}

	}

	void RecalculatePickups () {
		if (!won) {
			totalPickups--;
			pickupsLeft.text = "Pickups left: " + totalPickups.ToString ();
			if (totalPickups == 0) {
				won = true;
			}
		} else {
			pickupsLeft.text = "You had collected all the pickups!!!";
		}
	}

}
