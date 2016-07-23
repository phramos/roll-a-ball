using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

		void Update () {
			if (Input.GetKey (KeyCode.R)) {
				foreach (Transform child in this.transform) {
				
					child.gameObject.SetActive (true);
				}

				RestartGame ();
			}

			int nbTouches = Input.touchCount;

			if(nbTouches > 0){
				for (int i = 0; i < nbTouches; i++) {
					Touch touch = Input.GetTouch (i);

					if (touch.phase == TouchPhase.Began) {
						if (touch.tapCount >= 2) {
							RestartGame();
						}
							
					}
				}
			}
		}

		void RestartGame() {
			SceneManager.LoadScene (0);
		}
	
}

