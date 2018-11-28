using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excl1 : MonoBehaviour {

    public Renderer rend;
    public Timer2 timer;


    private bool on;

    // Use this for initialization
	void Start () {
        rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        print(Mathf.FloorToInt(timer.time));
        if (Mathf.FloorToInt(timer.time) % 5 == 0 && Mathf.FloorToInt(timer.time) < 120 && timer.inicio == true && rend.enabled == false)
        {
            rend.enabled = true;
        }
    }
}
