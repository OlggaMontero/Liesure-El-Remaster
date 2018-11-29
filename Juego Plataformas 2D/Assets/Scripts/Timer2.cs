using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour {

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;

    public float time;
    public float auxiliarTime;
    public bool inicio;
    public int recompensa;
    public Counter counter;

    // Use this for initialization
    void Start()
    {
        time = 120.0f; //120
        auxiliarTime = 0.0f;

        inicio = false;

        msgPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (inicio)
        {
            msgPanel.SetActive(true);
            time -= Time.deltaTime;
            msgText.text = "Tiempo restante: " + time.ToString("f0");
            recompensa = Mathf.RoundToInt(time);
            //Debug.Log(recompensa);
        }


        if (counter.contador > 3)
        {
            auxiliarTime += Time.deltaTime;
            if (auxiliarTime > 1)
            {
                SceneManager.LoadScene(3);      //reiniciar el nivel
            }
            
        }

        if (time < 0)
        {
            SceneManager.LoadScene(3);      //hemos ganado, pasar a la siguiente escena
        }


    }
}
