using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
    public Canvas menuSair;
    public Button jogarButton;
    public Button sairButton;

	// Use this for initialization
	void Start () {
        jogarButton = jogarButton.GetComponent<Button>();
        sairButton = sairButton.GetComponent<Button>();
        menuSair = menuSair.GetComponent<Canvas>();
        menuSair.enabled = false;
	}   
	

    public void SairPressed()
    {
        menuSair.enabled = true;
        jogarButton.enabled = false;
        sairButton.enabled = false;
    }
	// Update is called once per frame
	public void NaoPressed ()
    {
        menuSair.enabled = false;
        jogarButton.enabled = true;
        sairButton.enabled = true;
    }

    public void YesPressed()
    {
        Application.Quit();
    }

    public void JogarPresses ()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
