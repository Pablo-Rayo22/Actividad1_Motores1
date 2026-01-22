/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEngine;
using UnityEngine.Playables;

public class Secuencias : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    public PlayableDirector directorMuerte;
    [SerializeField] PlayableDirector directorVictoria;
    [SerializeField] GameObject activarCanvasMuerte;
    [SerializeField] GameObject activarCanvasVictoria;
    [SerializeField] MovimientoPersonaje personaje;

    // Variables privadas
    private bool secuenciaActiva = false;

    // Métodos
    private void OnTriggerEnter(Collider other)
    {
        ActivarSecuenciaVictoria(other.gameObject);
    }

    public void ActivarSecuenciaMuerte(GameObject collider)
    {
        if (collider.CompareTag("Trampas"))
        {
            activarCanvasMuerte.SetActive(false);
            BloquearMovimientoSecuencias();
            directorMuerte.Play();
            activarCanvasMuerte.SetActive(true);
            secuenciaActiva = true;
        }
    }

    private void ActivarSecuenciaVictoria(GameObject collider)
    {
        if (collider.CompareTag("Meta"))
        {
            directorVictoria.Play();
            activarCanvasVictoria.SetActive(true);
            BloquearMovimientoSecuencias();
        }
    }

    public void BloquearMovimientoSecuencias()
    {
        secuenciaActiva = true;
        personaje.bloqueado = true;
    }

    public void DesbloquearMovimientoSecuencias()
    {
        secuenciaActiva = false;
        personaje.bloqueado = false;
    }
    public bool FinCinematica()
    {
        return secuenciaActiva && directorMuerte.state != PlayState.Playing;
    }
}
