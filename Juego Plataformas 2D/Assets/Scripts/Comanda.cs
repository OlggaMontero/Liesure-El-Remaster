using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comanda : MonoBehaviour {

    public PlayerController2 player;
    public Barra barra;

    private bool inside;
	
    // Use this for initialization
	void Start () {
        inside = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (inside == true && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            if (player != null)                             //Hay que tener cuidado con las referencias NULL
            {
                if (player.nBandeja != 0)
                {
                    /*if (player.nMaleta == nHab)
                    {
                        //Debug.Log("¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                        msgText.text = "¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab;
                        msgPanel.SetActive(true);
                        timer.time += 10;
                        audio.PlayOneShot(tada, 1.0f);

                    }

                    else
                    {
                        //Debug.Log("¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                        msgText.text = "¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab;
                        msgPanel.SetActive(true);
                        timer.time -= 10;
                        audio.PlayOneShot(buzz, 1.0f);
                    }*/

                    barra.iList.Remove(player.nBandeja);
                    player.nBandeja = 0;

                }

                else
                {
                    Debug.Log("No traes comida!!");
                    //msgText.text = "No tienes ninguna maleta encima";
                    //msgPanel.SetActive(true);
                    //audio.PlayOneShot(error, 1.0f);

                }
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
            //msgPanel.SetActive(false);

        }
    }
}
