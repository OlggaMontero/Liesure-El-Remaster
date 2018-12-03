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

    // Use this for initialization
    void Start () {
        msgText.text = "Habla con el botones";
        msgPanel.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        

        if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            if (talk == false)
            {
                talk = true;
                msgText.text = "Coge las maletas del carrito y déjalas en las habitaciones correspondientes. ¡Ojo con el tiempo y con las maletas que caen!";
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
