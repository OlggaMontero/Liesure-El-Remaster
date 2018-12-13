using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hablar : MonoBehaviour {

    public Timer timer;
    public PlayerController player;

    private bool inside;
    private bool talk;

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    [SerializeField] GameObject msgPanelAux;


    // Use this for initialization
    void Start () {
        msgText.text = "¡Hey, tú, novato! Ven aquí que te explique lo que debes hacer.";
        msgPanel.SetActive(true);
        msgPanelAux.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        

        if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (talk == false)
            {
                talk = true;
                msgText.text = "Coge las maletas del carrito y déjalas en las habitaciones correspondientes. ¡Ojo con el tiempo y con las maletas que caen!";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
            }

            else
            {
                msgText.text = "¡Vamos! ¡Date prisa! ¡El tiempo no se detiene!";
                msgPanel.SetActive(true);
                msgPanelAux.SetActive(true);
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
            msgPanelAux.SetActive(false);
            if (talk)
            {
                timer.inicio = true;
            }
                
            

        }
    }
}
