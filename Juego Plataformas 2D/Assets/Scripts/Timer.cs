using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    public float time;
    public float auxiliarTime;
    public PickUp carrito;
    public bool inicio;
    public int recompensa;

    // Use this for initialization
    void Start () {
        time = 60.0f;
        auxiliarTime = 0.0f;

        inicio = false;

        msgPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (inicio)
        {
            msgPanel.SetActive(true);
            time -= Time.deltaTime;
            msgText.text = "" + time.ToString("f0");
            recompensa = Mathf.RoundToInt(time);
            //Debug.Log(recompensa);
        }
        

        if (time < 0)
        {
            SceneManager.LoadScene(2);      //reiniciar el nivel
        }

        if (carrito.iList.Count == 0)
        {
            auxiliarTime += Time.deltaTime;
            if (auxiliarTime > 1)
            {
                SceneManager.LoadScene("inicio");
            }
            

        }


    }
}
