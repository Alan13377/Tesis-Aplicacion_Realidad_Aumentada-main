using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true);
    }
}
