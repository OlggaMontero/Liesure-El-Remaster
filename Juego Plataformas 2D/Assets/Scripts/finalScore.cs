using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalScore : MonoBehaviour {

    [SerializeField] GameObject msgPanel;
    [SerializeField] Text msgText;
    private List<string> frases;
    private int index;

    // Use this for initialization
    void Start()
    {
        
        
        index = 0;

        frases = new List<string>();

        frases.Add("¡Buen trabajo joven!");
        frases.Add("Da gusto trabajar con personas tan aplicadas como tú");
        frases.Add("Bueno, vamos a lo que importa... tu sueldo");
        frases.Add("Por el día en las habitaciones conseguiste " + PlayerPrefs.GetInt("recompensa1") + " euros");
        frases.Add("No es mucho... pero bueno, tampoco esperarías hacerte rico ¿verdad?");
        frases.Add("Luego, por la noche en el restaurante ganaste " + PlayerPrefs.GetInt("recompensa2") + " euros");
        frases.Add("Que tampoco es una maravilla pero para ir tirando... ahí está");
        frases.Add("¡Espero verte trabajando de nuevo muy pronto!");
        frases.Add("Como si tuvieras otra opción...");
        frases.Add("¿Qué? Nada, nada, es que ya chocheo, no te preocupes");
        frases.Add("¡Hasta muy pronto!");

        msgPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        msgText.text = frases[index];

        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            index++;
        }

        if (index > 10)
        {
            SceneManager.LoadScene(0);      //vuelta al menú principal
        }

    }
}
