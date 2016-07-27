using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
    private Vector3 offsetInicial;

    private int fator;


	// Use this for initialization
	void Start () {
		offsetInicial = transform.position - player.transform.position;
        offset = offsetInicial;
        fator = 1;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            zoomOut();
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            zoomIn();
        }

        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            resetZoom();
        }
    }

    void zoomOut()
    {
        if (fator < 5)
        {
            fator++;
        }

        calculaOffset();

    }

    void zoomIn()
    {
        if (fator > 1)
        {
            fator--;
        }

        calculaOffset();
    }

    void resetZoom()
    {
        fator = 1;
        calculaOffset();
    }

    void calculaOffset()
    {
        offset = offsetInicial * fator;
    }

}
