using System;
using UnityEditor.EditorTools;
using UnityEngine;

public class TriggerPuerta : MonoBehaviour
{
    // Variables

    [Header("Variables serializadas")]
    [SerializeField] GameObject[] arrayPuertas = new GameObject[numPuertas];
    [SerializeField] bool[] arrayPuertasAbiertas = new bool[numPuertas];

    // Variables privadas
    //private bool puertaAbierta = false;
    private static int numPuertas = 3;
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
