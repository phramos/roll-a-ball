using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {
	private float maxY;
	private float minY;

	private float scaleRate;

	void Awake() {
		maxY = transform.position.y;
		minY = -4.5f;
		scaleRate= 0.1f;
	}

	// Update is called once per frame
	void Update () {
		ShrinkAndGrow ();
	}

	void ShrinkAndGrow() {

		if (transform.position.y < minY) {
			scaleRate = Mathf.Abs (scaleRate);
		} else if (transform.position.y > maxY) {
			scaleRate = -Mathf.Abs (scaleRate);
		}

		ApplyScaleRate ();

	}

	void ApplyScaleRate() {
		//transform.localScale += Vector3.one * scaleRate;
		//float newY = transform.position.y + scaleRate;
		Vector3 newPosition = new Vector3(0, scaleRate , 0);
		transform.position += newPosition;
	}
}
