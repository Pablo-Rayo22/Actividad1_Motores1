/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEngine;
using UnityEngine.Playables;

public class TrampasLaberinto : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] MovimientoPersonaje personaje;
    [SerializeField] Secuencias secuencias;

    // Variables privadas
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    // Métodos
    private void Start ()
    {
        posicionInicial = personaje.transform.position;
        rotacionInicial = personaje.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (secuencias.FinCinematica())
        {
            secuencias.DesbloquearMovimientoSecuencias();
            Reaparecer();
        }
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ActivarTrampa(hit.gameObject);
    }

    void ActivarTrampa(GameObject collider)
    {
        if (collider.CompareTag("Trampas"))
        {
            Debug.Log("Has muerto");
            secuencias.ActivarSecuenciaMuerte(collider);
        }
    }

    public void Reaparecer ()
    {
        personaje.transform.SetPositionAndRotation(posicionInicial, rotacionInicial);
    }
}