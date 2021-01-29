using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu2;

    public Text NuevaPartida;
    public Text GuardarPartida;
    public Text Creditos;
    public Text Salir;
    public Text seleccionarSlot;
    public Text volver;


    private void Start()
    {
        Menu1();

        if(GameManager.instance.language == "es")
        {
            NuevaPartida.text = "Nueva partida";
            GuardarPartida.text = "Cargar partida";
            Creditos.text = "Créditos";
            Salir.text = "Salir";
            seleccionarSlot.text = "Selecciona un slot:";
            volver.text = "Volver";

        }
        else
        {
            NuevaPartida.text = "New game";
            GuardarPartida.text = "Load game";
            Creditos.text = "Credits";
            Salir.text = "Quit game";
            seleccionarSlot.text = "Select game:";
            volver.text = "Back";
        }
    }

    public void Menu1()
    {
        //GameManager.instance.setIsCargarPartida(false);
        menu1.SetActive(true);
        menu2.SetActive(false);
    }

    public void EmpezarPartida()
    {
        //GameManager.instance.setIsCargarPartida(false);
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    public void CargarPartida()
    {
        //GameManager.instance.setIsCargarPartida(true);
        menu1.SetActive(false);
        menu2.SetActive(true);
    }

    public void GoToCredits()
    {
        GameManager.instance.LoadScene("Creditos");
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }
}
