using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 

    public void CargaJuego(string pNombreEscena)
    {
        SceneManager.LoadScene(pNombreEscena);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EntrarOpciones()
    {

    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("salir");
    }
}
