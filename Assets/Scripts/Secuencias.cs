/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEngine;

public class Secuencias : MonoBehaviour
{

    // Variables
    [Header("Variables serializadas")]
    [SerializeField] GameObject activarCanvasVictoria;
    [SerializeField] GameObject activarCanvasMuerte;

    // Métodos
    private void OnTriggerEnter(Collider other)
    {
        ActivarSecuenciaVictoria(other.gameObject);
    }

    private void ActivarSecuenciaVictoria(GameObject collider)
    {
        if (collider.CompareTag("Meta"))
        {
            activarCanvasVictoria.SetActive(true);
        }
    }

    public  void ActivarSecuenciaMuerte (GameObject collider)
    {
        if (collider.CompareTag("Trampas"))
        {
            activarCanvasMuerte.SetActive(false);
            activarCanvasMuerte.SetActive(true);
        }
    }

}
