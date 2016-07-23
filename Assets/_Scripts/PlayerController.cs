using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public Text timeMessage;
	public Text pickupsLeft;


	public float timeSinceReset;
	public float speed;

	private string minutes;
	private string seconds;

	private Rigidbody player;
	private int totalPickups;

	private bool _isPlayerWon;
	private bool _isGameInProgres;

	void Awake () {
		
		player = GetComponent<Rigidbody> ();
		totalPickups = 25;

		_isPlayerWon = false;
		_isGameInProgres = true;

		pickupsLeft.text = "Items restantes: " + totalPickups.ToString();
	
	}


	void Start() {
		
		RecalculateTime ();

	}

	void Update () {
		
		if (_isGameInProgres) {
			RecalculateTime (); 
		}

		if (!_isGameInProgres && Input.GetKey(KeyCode.R)){
			RestartGame ();
		}
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
			
		} else if (other.gameObject.CompareTag ("Enemy")) {
			RestartGame ();
		}
	}

	void RecalculateTime() {

		if (_isGameInProgres) {
			minutes = Mathf.Floor (Time.timeSinceLevelLoad / 60).ToString ("00");
			seconds = ((Time.timeSinceLevelLoad) % 60).ToString ("00");

			timeMessage.text = "Tempo: " + minutes + ":" + seconds;
		} else {
			timeMessage.text = "Você coletou tudo em: " + minutes + ":" + seconds;
		}

	}

	void RecalculatePickups () {
		if (_isGameInProgres) {
			totalPickups--;
			speed++;
			pickupsLeft.text = "Itens estantes: " + totalPickups.ToString ();
			if (totalPickups == 0) {

				_isGameInProgres = !_isGameInProgres;
				_isPlayerWon = true;

			}
		} 
			
	}

	void RestartGame() {
		timeSinceReset = Time.realtimeSinceStartup;
		SceneManager.LoadScene (0);
	}

	float getCurrentTime() {
		return Time.realtimeSinceStartup - timeSinceReset;
	}

}
