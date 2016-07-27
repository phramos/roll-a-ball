using UnityEngine;
using System.Collections;

public class DiaENoite : MonoBehaviour {

    public Light luz;
    Color dia = new Color(1F, 0.957F, 0.839F, 1F);
    Color noite = new Color(0.149F, 0.141F, 0.129F, 1F);

    // Use this for initialization
    void Start () {
        luz = GetComponent<Light>();
        luz.color = dia;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.N))
        {
            toggleDiaNoite();

        }
    }

    void toggleDiaNoite()
    {
        if (luz.color.Equals(dia))
        {
            luz.color = noite;
        }
        else
        {
            luz.color = dia;
        }
    }
}
