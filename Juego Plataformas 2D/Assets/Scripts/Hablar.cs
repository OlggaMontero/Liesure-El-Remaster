using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hablar : MonoBehaviour {

    public Timer timer;

    private bool inside;
    private bool talk;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    // Use this for initialization
    void Start () {
        msgPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        

        if (inside == true && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            if (talk == false)
            {
                talk = true;
                msgText.text = "Pulsa CUADRADO para coger maletas del carrito y dejarlas en la habitación correspondiente. ¡Ojo con el tiempo y con las maletas!";
                msgPanel.SetActive(true);
            }

            else
            {
                msgText.text = "¡Vamos! ¡Date prisa! ¡El tiempo no se detiene!";
                msgPanel.SetActive(true);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inside = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inside = false;
            msgPanel.SetActive(false);
            if (talk)
            {
                timer.inicio = true;
            }
                
            

        }
    }
}
