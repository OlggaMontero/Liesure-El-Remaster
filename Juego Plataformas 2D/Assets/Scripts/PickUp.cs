using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    public PlayerController player;
    public List<int> iList;
    public Timer timer;

    //private float time; 

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;


    private bool inside;

    // Use this for initialization
    void Start()
    {
        inside = false;
        player.carry = false;

        iList = new List<int>();

        
        iList.Add(46);
        iList.Add(53);
        iList.Add(531);
        iList.Add(73);
        iList.Add(331);
        iList.Add(2);
        iList.Add(7);
        iList.Add(842);
        iList.Add(732);
        iList.Add(634);

        msgPanel.SetActive(false);

        //time = 0.0f;



    }

    void Update()
    {

        //time += Time.deltaTime;
        
        if (timer.inicio)
        {
            if (inside == true && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
            {
                if (player != null)                             //Hay que tener cuidado con las referencias NULL
                {
                    if (iList.Count > 0)
                    {
                        if (player.carry == false)
                        {
                            player.carry = true;
                            player.nMaleta = iList[Random.Range(0, iList.Count - 1)];
                            msgText.text = "Toma la maleta " + player.nMaleta;
                            msgPanel.SetActive(true);

                        }

                        else
                        {
                            //Debug.Log("Ya llevas encima la maleta " + player.nMaleta);
                            msgText.text = "Ya llevas encima la maleta " + player.nMaleta;
                            msgPanel.SetActive(true);

                        }
                    }
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
