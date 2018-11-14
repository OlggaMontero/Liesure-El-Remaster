using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    //public PlayerController player;
    public Spawner spawn;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Destroy"+spawn.player.carry);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainGround")
        {
            Destroy(gameObject, 0.01f);
            
        }

        if (col.gameObject.tag == "Player")
        {
            if (spawn.player.carry == true)
            {
                spawn.player.carry = false;
                //Debug.Log(player.carry);
                Debug.Log("Se te ha caído la maleta " + spawn.player.nMaleta);
            }

            else
            {
                Debug.Log("Menos mal que no tenías ninguna maleta encima...");
            }

            Destroy(gameObject, 0.01f);
            
        }
    }
}
