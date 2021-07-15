using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraja : MonoBehaviour
{

    public int numCarta = 0;
    public Vector3 posicionPred;
    public Texture2D texturaFrente;
    public Texture2D texturaReversed;

    public float tiempoDelay;
    public GameObject matricesintentos;

    public bool MostrarPuntuacion;

    public GameObject interfaz;
   


    void Awake(){
        matricesintentos = GameObject.Find("Scripts");
        interfaz = GameObject.Find("Scripts");
    }

    void Start(){
        OcultarObra();
    }

    void OnMouseDown(){
        if(!interfaz.GetComponent<Interfaz>().menuActivo){
            MostrarObras();
        }
        
    }

    public void AsignarImg(Texture2D _textura){
        texturaFrente = _textura;

       
    }

    public void MostrarObras(){
        if(!MostrarPuntuacion && matricesintentos.GetComponent<Matrices>().mostrar){
            MostrarPuntuacion = true;

        GetComponent<MeshRenderer>().material.mainTexture = texturaFrente;
        
        matricesintentos.GetComponent<Matrices>().TocarCartas(this);
        }
    }

    public void OcultarObra(){
        Invoke("Esconder",tiempoDelay);
        matricesintentos.GetComponent<Matrices>().mostrar = false;
        
    }

    void Esconder(){
        GetComponent<MeshRenderer>().material.mainTexture = texturaReversed;
        MostrarPuntuacion = false;
        matricesintentos.GetComponent<Matrices>().mostrar = true;
    }
}
