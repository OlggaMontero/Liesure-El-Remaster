using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Deliver : MonoBehaviour {

    public PlayerController player;
    public PickUp carrito;
    public float nHab;

    private bool inside;

    // Use this for initialization
    void Start () {
        inside = false;
        
    }

    void Update()
    {
        //Debug.Log(carrito.iList.Count);

        if (inside == true && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            if (player != null)                             //Hay que tener cuidado con las referencias NULL
            {
                if (player.carry == true)
                {
                    if (player.nMaleta == nHab)
                    {
                        Debug.Log("¡GENIAL! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                        
                    }

                    else
                    {
                        Debug.Log("¡OH NO! Has entregado la maleta " + player.nMaleta + " en la habitación " + nHab);
                    }

                    carrito.iList.Remove(player.nMaleta);
                    if (carrito.iList.Count == 0)
                    {
                        SceneManager.LoadScene("inicio");
                    }
                    player.carry = false;
                    
                }

                else
                {
                    Debug.Log("No tienes ninguna maleta encima");
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

        }
    }





    // Update is called once per frame
    /* void Update () {
         if (transform.position.x > player.transform.position.x -0.3 && transform.position.x < player.transform.position.x + 0.3
             && transform.position.y > player.transform.position.y - 0.3 && transform.position.y < player.transform.position.y + 0.3)
         {
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 Debug.Log("AHHHHHHHHHHHH");
             }

         }
     }*/



}
