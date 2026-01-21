/*
Autor: Pablo Jiménez García
Asignatura: Motores para Videojuegos 1 
*/

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerInterruptor : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] LayerMask layerMask;
    [SerializeField] Canvas detectorCanvasDisparo;
    [SerializeField] InputActionReference disparar;
    [SerializeField] TriggerPuerta puerta;

    //Variables privadas
    private bool disparo = false;
    private const float distanciaMaxima = 4;

    // Métodos
    private void Update()
    {
        detectorCanvasDisparo.gameObject.SetActive(false);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanciaMaxima, layerMask))
        {
            if (hit.collider)
            {
                detectorCanvasDisparo.gameObject.SetActive(true);
                DispararRayo(hit.collider.name);
            }
            
        }
    }

    private void OnEnable()
    {
        disparar.action.Enable();

        disparar.action.started += OnDisparar;
        disparar.action.performed += OnDisparar;
        disparar.action.canceled += OnDisparar;
    }

    private void OnDisable()
    {
        disparar.action.Disable();

        disparar.action.started -= OnDisparar;
        disparar.action.performed -= OnDisparar;
        disparar.action.canceled -= OnDisparar;
    }

    private void OnDisparar(InputAction.CallbackContext context)
    {
        disparo = context.ReadValueAsButton();
        Debug.Log(context.control.device.name);
    }

    private void DispararRayo(string nombreInterruptor)
    {
        int numPuerta = default;
        if (disparo)
        {
               switch (nombreInterruptor)
            {
               case "Interruptor1":
               {
                    numPuerta = 0;
                    break;
               }
               case "Interruptor2":
               {
                   numPuerta = 1;
                   break;
               }
               case "Interruptor3":
               {
                   numPuerta = 2;
                   break;
               }
            }
            Debug.Log($"{nombreInterruptor} accionado. Puerta{numPuerta + 1} abierta");
            puerta.AbrirPuertas(numPuerta);
        }
    }
}