using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excl1 : MonoBehaviour {

    public Renderer rend;
    public Timer2 timer;
    public bool on;
    public Counter counter;
    public float auxTime;
    public Comanda mesa;

    public int divisor;
    //divisor = 5 en el primer ejemplo
    public int espera;
    //tiempo de espera para que salga de nuevo la exclamación

    



    // Use this for initialization
    void Start () {
        rend.enabled = false;
        on = false;
        auxTime = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        //print(auxTime);
        if (timer.inicio)
        {
            auxTime += Time.deltaTime;
        }

        if (Mathf.FloorToInt(timer.time) % divisor == 0 && Mathf.FloorToInt(timer.time) < 120 && timer.inicio == true && rend.enabled == false && auxTime>espera && mesa.buffet == false)
        {
            on = true;
            counter.contador++;
        }

        if (on)
        {
            rend.enabled = true;

        }

        else if (!on)
        {
            rend.enabled = false;
        }
    }
}
