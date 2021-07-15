using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interfaz : MonoBehaviour
{
   public GameObject menu;
   public GameObject menuGanador;
   public bool menuActivo;
   public bool menuMostradoGanador;
   

    public void MostrarMenu(){
        menu.SetActive(true);
        menuActivo = true;
    }

    public void EsconderMenu(){
        menu.SetActive(false);
        menuActivo = false;
    }


    public void MostrarMenuGanador(){
		menuGanador.SetActive (true);
		menuMostradoGanador = true;
	}

	public void EsconderMenuGanador(){
		menuGanador.SetActive (false);
		menuMostradoGanador = false;
	}
}
