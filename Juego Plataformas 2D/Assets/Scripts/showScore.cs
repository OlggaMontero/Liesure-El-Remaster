using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showScore : MonoBehaviour {

    [SerializeField] Text msgText;

    // Use this for initialization
    void Start () {
        msgText.text = "Recompensa: " + Score.recompensa.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
