using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text timeMessage;
	public Text pickupsLeft;
    public Text help;

	public AudioClip audioMalandramente;
	public AudioClip audioAiSafada;

	public float timeSinceReset;
	public float speed;

	private string minutes;
	private string seconds;

	private Rigidbody player;
	private int totalPickups;

	private bool _isPlayerWon;
	private bool _isGameInProgres;

    public GameObject camSuperior;
    public GameObject cam3aPessoa;

	void Awake () {
		
		player = GetComponent<Rigidbody> ();

		totalPickups = 25;

		_isPlayerWon = false;
		_isGameInProgres = true;

		pickupsLeft.text = "Malandragens restantes: " + totalPickups.ToString();
        help.text = "Ajuda (H)";

        camSuperior.active = false;
        cam3aPessoa.active = true;
        
	}
		

	void Update () {
		
		if (_isGameInProgres) {
			RecalculateTime (); 
		}

        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleCamera();

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            toggleAjuda();

        }
    }

    void toggleCamera()
    {

        cam3aPessoa.active = !cam3aPessoa.active;
        camSuperior.active = !camSuperior.active;
    }

    void toggleAjuda()
    {

        if (help.text.Equals("Ajuda (H)"))
        {

            help.text = "Comandos:\nMovimentar (Setas)\nReiniciar (R)\nMudar Camera (C)\nAlternar Dia/Noite (N)\nAproximar (-)\nAfastar (+)\nRedefinir Zoom(*)\nFechar Ajuda(H)";
        }
        else
        {

            help.text = "Ajuda (H)";
        }
    }

    void FixedUpdate() {
		
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis ("Vertical"); 

		Vector3 moviment = new Vector3 (moveHorizontal, 0, moveVertical);

		player.AddForce (moviment * speed);

		transform.Translate (Input.acceleration.x, 0, -Input.acceleration.z);

	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.CompareTag ("Pickup")) {

			other.gameObject.SetActive (false);
			AudioSource.PlayClipAtPoint (audioMalandramente, transform.position);

			RecalculatePickups (); 
			
		} else if (other.gameObject.CompareTag ("Enemy")) {
			//gameObject.SetActive (false);
			AudioSource.PlayClipAtPoint (audioAiSafada, transform.position);
			PlayerPerdeu ();
		}
	}

	void RecalculateTime() {

		if (_isGameInProgres) {
			minutes = Mathf.Floor (Time.timeSinceLevelLoad / 60).ToString ("00");
			seconds = ((Time.timeSinceLevelLoad) % 60).ToString ("00");

			timeMessage.text = "Tempo: " + minutes + ":" + seconds;
		}

	}

	void RecalculatePickups () {
		if (_isGameInProgres) {
			totalPickups--;
			speed++;
			pickupsLeft.text = "Maladragens  restantes: " + totalPickups.ToString ();
			if (totalPickups == 0) {
				PlayerVenceu ();
			}
		} 
			
	}



	float getCurrentTime() {
		return Time.realtimeSinceStartup - timeSinceReset;
	}

	void PlayerVenceu(){
		gameObject.SetActive(false);
		_isGameInProgres = false;
		_isPlayerWon = true;
		UpdateUI ();
	}


	void PlayerPerdeu(){
		gameObject.SetActive(false);
		_isGameInProgres = false;
		_isPlayerWon = false;
		UpdateUI ();
	}

	void UpdateUI() {
		timeMessage.text = "Aperte R para jogar novamente ou Esc pra voltar ao menu";
		if (_isPlayerWon) {
			pickupsLeft.text = "Parabéns, a menina levou madeirada em " + minutes + " minutos " + seconds + " segundos";
		} else {
			pickupsLeft.text = "Nois se vê por aíi!";
		}
	}
}
