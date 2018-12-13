using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comanda : MonoBehaviour {

    public PlayerController2 player;
    public Barra barra;
    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;
    public excl1 hambre;
    public Counter counter;
    public bool buffet;
    //será true para la mesa buffet y false para el resto
    public updScore control;

    private bool inside;
    
	
    // Use this for initialization
	void Start () {
        inside = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        
        

        if (inside == true && player.pause == false && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            if (player != null)                             //Hay que tener cuidado con las referencias NULL
            {
                if (player.nBandeja < 0)
                {
                    if (buffet == false)
                    {
                        if (hambre.on)
                        {
                            //Debug.Log("¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                            msgText.text = "¡GRACIAS! Nos moríamos de hambre.";
                            control.recompensa2 += 10;
                            msgPanel.SetActive(true);
                            hambre.on = false;
                            hambre.auxTime = 0;
                            counter.contador--;
                            //timer.time += 10;
                            //audio.PlayOneShot(tada, 1.0f);

                        }

                        else
                        {
                            //Debug.Log("¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                            msgText.text = "Nosotros no habíamos pedido nada.";
                            if (control.recompensa2 -5 >= 0)
                            {
                                control.recompensa2 -= 5;
                            }
                            msgPanel.SetActive(true);
                            //timer.time -= 10;
                            //audio.PlayOneShot(buzz, 1.0f);
                        }
                    }

                    else                    //le damos una bandeja de plata a la mesa buffet
                    {
                        msgText.text = "¡¡Esto es una porquería!!";
                        if (control.recompensa2 - 10 >= 0)
                        {
                            control.recompensa2 -= 10;
                        }
                        msgPanel.SetActive(true);
                    }

                    barra.iList.Remove(player.nBandeja);
                    player.nBandeja = 0;

                }

                else if (player.nBandeja > 0)
                {
                    if (buffet == false)
                    {
                        if (hambre.on)
                        {
                            //Debug.Log("¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                            msgText.text = "¡Vaya! Esto es incluso mejor que lo que habíamos pedido.";
                            if (control.recompensa2 - 5 >= 0)
                            {
                                control.recompensa2 -= 5;
                            }
                            msgPanel.SetActive(true);
                            hambre.on = false;
                            hambre.auxTime = 0;
                            counter.contador--;
                            //timer.time += 10;
                            //audio.PlayOneShot(tada, 1.0f);

                        }

                        else
                        {
                            //Debug.Log("¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                            msgText.text = "Nosotros no habíamos pedido nada. Y menos tan caro.";
                            if (control.recompensa2 - 10 >= 0)
                            {
                                control.recompensa2 -= 10;
                            }
                            msgPanel.SetActive(true);
                            //timer.time -= 10;
                            //audio.PlayOneShot(buzz, 1.0f);
                        }
                    }

                    else                    //le damos una bandeja de oro a la mesa buffet
                    {
                        msgText.text = "¡¡Está todo buenísimo!!";
                        control.recompensa2 += 10;
                        msgPanel.SetActive(true);
                    }

                    barra.iList.Remove(player.nBandeja);
                    player.nBandeja = 0;
                }

                else
                {
                    //Debug.Log("No traes comida!!");
                    msgText.text = "¡No traes comida!";
                    if (control.recompensa2 - 1 >= 0)
                    {
                        control.recompensa2 -= 1;
                    }
                    msgPanel.SetActive(true);
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
            msgPanel.SetActive(false);

        }
    }
}
