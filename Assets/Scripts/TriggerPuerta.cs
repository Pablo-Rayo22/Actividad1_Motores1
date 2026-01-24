/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEngine;

public class TriggerPuerta : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] GameObject[] arrayPuertas;
    [SerializeField] bool[] arrayPuertasAbiertas;

    // Variables privadas
    private const float desplazamientoPuerta = 5f;

    // Métodos
    public void AbrirPuertas (int numPuerta)
    {
        Vector3 traslacionPuerta = Vector3.up * desplazamientoPuerta;
        GameObject puertaMover = arrayPuertas[numPuerta];

        if (!arrayPuertasAbiertas[numPuerta])
        {
            puertaMover.transform.Translate(traslacionPuerta);
            arrayPuertasAbiertas[numPuerta] = true;
        }
    }
}
