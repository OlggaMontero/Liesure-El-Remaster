using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static int recompensa = 0;
    public Timer timer;

    // Use this for initialization
    void Start () {
		
	}

    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        recompensa = timer.recompensa*10;

	}
}
