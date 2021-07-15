using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Matrices : MonoBehaviour
{
    public GameObject barajaPrefab;
    public int ancho;
    public int alto;
    public Transform cartasParent;
    private List<GameObject> cartas = new List<GameObject>();

    public Material[] materials;
    public Texture2D[] texturas;

    public int contadorIntentos;

    public Text intentos;

    public Baraja CartaMostrada;
    public Interfaz Interfaz_Usuario;
    public bool mostrar = true;

    public int paresEncontradas;
  

    public void Reiniciar(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


    public void Crear(){
        int cont = 0;
        for (int i = 0; i <ancho;i++){
            for (int j = 0; j < ancho; j++){
                float factor = 9.0f/ancho;
                Vector3 posicionTemp = new Vector3(j*factor,0,i*factor);

                GameObject cartaTemp = Instantiate(barajaPrefab,posicionTemp,
                    Quaternion.Euler(new Vector3(0,180,0)));

                cartaTemp.transform.localScale *= factor;

                cartas.Add(cartaTemp);
                cartaTemp.GetComponent<Baraja>().posicionPred = posicionTemp;
                cartaTemp.GetComponent<Baraja>().numCarta = cont;
                cartaTemp.transform.parent = cartasParent;
                cont++;

            }
        }

        AsignarObras();
        Aleatorio();
    }

    void AsignarObras(){
        for (int i = 0; i < cartas.Count; i++){
            cartas[i].GetComponent<Baraja>().AsignarImg(texturas[(i)/2]);
            cartas[i].GetComponent<Baraja>().numCarta = i/2;
        }
    }
    void Aleatorio(){
        int aleatory;
        for (int i = 0; i < cartas.Count; i++){
            aleatory = Random.Range(i, cartas.Count);

            cartas [i].transform.position = cartas[aleatory].transform.position;
            cartas [aleatory].transform.position = cartas [i].GetComponent<Baraja>().posicionPred;

            cartas [i].GetComponent<Baraja>().posicionPred = cartas [i].transform.position;
            cartas [aleatory].GetComponent<Baraja>().posicionPred = cartas [aleatory].transform.position;

        }
    }

    public void TocarCartas(Baraja _carta){
        if(CartaMostrada == null ){
            CartaMostrada = _carta;
        }else{
           
                contadorIntentos++;
                ActualizarMarcador();
                
            if(CompararCartas(_carta.gameObject,CartaMostrada.gameObject)){
                print("Encontraste una pareja");
                paresEncontradas++;
                if(paresEncontradas == cartas.Count / 2){
                    print("SON todas");
                  Interfaz_Usuario.MostrarMenuGanador();
                   
                }

            }else{
                
                _carta.OcultarObra();
                CartaMostrada.OcultarObra();
            }
            CartaMostrada = null;
        }
        ;
    }

    public bool CompararCartas(GameObject carta1, GameObject carta2){
        bool result;
        if(carta1.GetComponent<Baraja>().numCarta ==
        carta2.GetComponent<Baraja>().numCarta){
            result = true;
        }else{
            result = false;
        }
        return result;
    }

    public void ActualizarMarcador(){
        intentos.text = "Intentos: " +contadorIntentos;
    }
}

