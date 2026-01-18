using System.Security.Cryptography.X509Certificates;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerInterruptor : MonoBehaviour
{
    // Variables
    [Header("Variables serializadas")]
    [SerializeField] int distanciaMaxima = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Canvas detectarCanvasDisparo;
    [SerializeField] InputActionReference disparar;
    [SerializeField] TriggerPuerta puerta;

    //Variables privadas
    private bool disparo = false;
    //private bool puertaAbierta = false;

    enum listaInterruptores
    {
        interruptor1,
        interruptor2, 
        interruptor3
    }

    // El método update se llama cada frame (cada pintada de pantalla)
    private void Update()
    {
        detectarCanvasDisparo.gameObject.SetActive(false);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distanciaMaxima, layerMask))
        {
            if (hit.collider)
            {
                detectarCanvasDisparo.gameObject.SetActive (true);
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